using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float shootSpeed = 12.0f;         //��̑��x
    public float shootDelay = 0.25f;         //���ˊԊu
    public GameObject bowPrefab;             //�|�̃v���n�u
    public GameObject arrowPrefab;           //��̃v���n�u
    bool inAttack = false;                   //�U�����t���O
    GameObject bowObj;                       //�|�̃Q�[���I�u�W�F�N�g

    void Start()
    {
        //�|���v���C���[�L�����N�^�[�ɔz�u
        Vector3 pos = transform.position;
        bowObj = Instantiate(bowPrefab, pos, Quaternion.identity);
        bowObj.transform.SetParent(transform);  //�|�̐e�Ƀv���C���[�L�����N�^�[��ݒ肷��
    }

   
    void Update()
    {
        if ((Input.GetButtonDown("Fire3")))
        {
            //�U���L�[�������ꂽ
            Attack();
        }
        //�|�̉�]�ƗD�揇��
        float bowZ = -1;      //�|��Z�l�i�L�����N�^�[�̑O�ɂ���j
        PlayerController plmv = GetComponent<PlayerController>();
        if (plmv.angleZ > 30 && plmv.angleZ < 150)
        {
            //�����
            bowZ = 1;     //�|��Z�l�i�L�����N�^�[�̌��ɂ���j
        }
        //�|�̉�]
        bowObj.transform.rotation = Quaternion.Euler(0, 0, plmv.angleZ);
        //�|�̗D�揇��
        bowObj.transform.position = new Vector3(transform.position.x, 
            transform.position.y, bowZ);
    }

    /// <summary>
    /// �U��
    /// </summary>
    public void Attack()
    {
        //��������Ă���@&�@�U�����ł͂Ȃ�
        if (ItemKeeper.hasArrows > 0 && inAttack == false)
        {
            ItemKeeper.hasArrows -= 1;    //������炷
            inAttack = true;       //�U���t���O�𗧂Ă�
            //�������
            PlayerController playerCnt = GetComponent<PlayerController>();
            float angleZ = playerCnt.angleZ;     //��]�p�x
            //��̃Q�[���I�u�W�F�N�g�����i�i�s�����ɉ�])
            Quaternion r = Quaternion.Euler(0, 0, angleZ);
            GameObject arrowObj = Instantiate(arrowPrefab, transform.position, r);
            //��𔭎˂���x�N�g�������
            float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
            float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
            Vector3 v = new Vector3(x, y) * shootSpeed;
            //��ɗ͂�������
            Rigidbody2D rb = arrowObj.GetComponent<Rigidbody2D>();
            rb.AddForce(v, ForceMode2D.Impulse);
            //�U���t���O�����낷�x���s��
            Invoke("StopAttack", shootDelay);
        }
    }
    /// <summary>
    /// �U����~
    /// </summary>
    public void StopAttack()
    {
        inAttack = false;    //�U���t���O�����낷
    }
}
