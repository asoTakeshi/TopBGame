using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject swordPrefab;             //���̃v���n�u
    bool inAttack = false;                   //�U�����t���O
    GameObject swordObj;
    void Start()
    {
        //�����v���C���[�L�����N�^�[�ɔz�u
        Vector3 pos = transform.position;
        swordObj = Instantiate(swordPrefab, pos, Quaternion.identity);
        swordObj.transform.SetParent(transform);  //���̐e�Ƀv���C���[�L�����N�^�[��ݒ肷��
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire3")))
        {
            //�U���L�[�������ꂽ
            Attack();
        }
    }
    /// <summary>
    /// �U��
    /// </summary>
    public void Attack()
    {
        //�U�����ł͂Ȃ�
        if (inAttack == false)
        {
            //ItemKeeper.hasArrows > 0
            //ItemKeeper.hasArrows -= 1;    //������炷
            inAttack = true;       //�U���t���O�𗧂Ă�
            //�������
            PlayerController playerCnt = GetComponent<PlayerController>();
            //float angleZ = playerCnt.angleZ;     //��]�p�x
            //��̃Q�[���I�u�W�F�N�g�����i�i�s�����ɉ�])
           // Quaternion r = Quaternion.Euler(0, 0, angleZ);
            //GameObject arrowObj = Instantiate(arrowPrefab, transform.position, r);
            //��𔭎˂���x�N�g�������
           // float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
           // float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
            //Vector3 v = new Vector3(x, y) * shootSpeed;
            //��ɗ͂�������
           // Rigidbody2D rb = arrowObj.GetComponent<Rigidbody2D>();
           // rb.AddForce(v, ForceMode2D.Impulse);
            //�U���t���O�����낷�x���s��
            //Invoke("StopAttack", shootDelay);
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
