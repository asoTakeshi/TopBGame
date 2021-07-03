using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�ړ��X�s�[�h
    public float speed = 3.0f;
    //�A�j���[�V������
    public string upAnime = "PlayerUp";          //�����
    public string downAnime = "PlayerDown";      //������
    public string rightAnime = "PlayerRight";    //�����
    public string leftAnime = "PlayerLeft";      //������
    public string deadAnime = "PlayerDead";      //���S
    //���݂̃A�j���[�V����
    string nowAnimation = "";
    //�ȑO�̃A�j���[�V����
    string oldAnimation = "";

    float axisH;           //�����l(-1.0 �` 0.0 �` 1.0)
    float axisV;           //�c���l(-1.0 �` 0.0 �` 1.0)
    public float angleZ = -90.0f;      //��]��
    Rigidbody2D rb;         //Rigidbody2D
    bool isMoving = false;  //�ړ����t���O
    //�_���[�W�Ή�
    public static int hp = 3;       //player��HP
    public static string gameState;  //�Q�[���̏��
    bool inDamage = false;           //�_���[�W���t���O

    void Start()
    {
        //Rigidbody2D���擾
        rb = GetComponent<Rigidbody2D>();
        //�A�j���[�V����
        oldAnimation = downAnime;
        //�Q�[���̏�Ԃ��v���C���ɂ���
        gameState = "playing";
    }
    void Update()
    {
        //�Q�[�����ȊO�ƃ_���[�W���͉������Ȃ�
        if (gameState != "playing" || inDamage)
        {
            return;
        }
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");   //���E�L�[����
            axisV = Input.GetAxisRaw("Vertical");     //�㉺�L�[����
        }
        //�L�[���͂���ړ��p�x�����߂�
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);
        //�ړ��p�x��������Ă�������ƃA�j���[�V�����X�V
        if (angleZ >= -45 && angleZ < 45)
        {
            //�E����
            nowAnimation = rightAnime;
        }
        else if (angleZ >= 45 && angleZ <= 135)
        {
            //�����
            nowAnimation = upAnime;
        }
        else if (angleZ >= -135 && angleZ <= -45)
        {
            //������
            nowAnimation = downAnime;
        }
        else
        {
            //������
            nowAnimation = leftAnime;
        }
        //�A�j���[�V�����؂�ւ���
        if (nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            GetComponent<Animator>().Play(nowAnimation);
        }
    }
    private void FixedUpdate()
    {
        //�Q�[�����ȊO�͉������Ȃ�
        if (gameState != "playing")
        {
            return;
        }
        if (inDamage)
        {
            //�_���[�W���_�ł�����
            float val = Mathf.Sin(Time.time * 50);
            Debug.Log(val);
            if(val > 0)
            {
                //�X�v���C�g��\��
                gameObject.GetComponent<SpriteRenderer>().enabled = true;

            }
            else
            {
                //�X�v���C�g���\��
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            return;      //�_���[�W���͑���ɂ��ړ��������Ȃ�
        }
        //�ړ����x���X�V����
        rb.velocity = new Vector2(axisH, axisV) * speed;
    }
    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
    /// <summary>
    /// p1����p2�̊p�x��Ԃ�
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if (axisH != 0 || axisV != 0)
        {
            //�ړ����ł���Ίp�x���X�V����
            //p1����p2�ւ̍���(���_��0�ɂ���)
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            //�A�[�N�^���W�F���g2���֐��Ŋp�x�����߂�
            float rad = Mathf.Atan2(dy, dx);
            //���W�A����x�ɕϊ����ĕԂ�
            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            //��~���ł���ΈȑO�̊p�x���ێ�
            angle = angleZ;
        }
        return angle;
    }

    /// <summary>
    /// �ڐG�i�����j
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            GetDamage(col.gameObject);
        }

    }

    /// <summary>
    /// �_���[�W
    /// </summary>
    /// <param name="enemy"></param>
    void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            hp--;     //HP�����炷
            Debug.Log("Player HP=" + hp);
            if(hp > 0)
            {
                //�ړ���~
                rb.velocity = new Vector2(0, 0);
                //�G�L�����̔��Ε����Ƀq�b�g�o�b�N������
                Vector3 v = (transform.position - enemy.transform.position).normalized;
                rb.AddForce(new Vector2(v.x * 4, v.y * 4), ForceMode2D.Impulse);
                //�_���[�W�t���OON
                inDamage = true;
                Invoke("DamageEnd", 0.25f);
            }
            else
            {
                //�Q�[���I�[�o�[
                GameOver();
            }
        }
    }
    /// <summary>
    /// �_���[�W�I��
    /// </summary>
    void DamageEnd()
    {
        //�_���[�W�t���OOFF
        inDamage = false;
        //�X�v���C�g�����ɖ߂�
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    /// <summary>
    /// �Q�[���I�[�o�[
    /// </summary>
    void GameOver()
    {
        Debug.Log("�Q�[���I�[�o�[");
        gameState = "gameover";
        //===================
        //�Q�[���I�[�o�[���o
        //===================
        //�v���C���[�����������
        GetComponent<CircleCollider2D>().enabled = false;
        //�ړ���~
        rb.velocity = new Vector2(0, 0);
        //�d�͂�߂��ăv���C���[����ɏ������ˏグ�鉉�o
        rb.gravityScale = 1;
        rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        //�A�j���[�V������؂�ւ���
        GetComponent<Animator>().Play(deadAnime);
        //1�b��Ƀv���C���[�L�����N�^�[������
        Destroy(gameObject, 1.0f);
    }
}
