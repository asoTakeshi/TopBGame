using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float deleteTime = 2;    //�폜����
    void Start()
    {
        Destroy(gameObject, deleteTime);     //��莞�Ԃŏ���
    }

    
    void Update()
    {
        
    }
    //�Q�[���I�u�W�F�N�g�ɐڐG
    private void OnCollisionEnter2D(Collision2D col)
    {
        //�ڐG�����Q�[���I�u�W�F�N�g�̎q�ɂ���
        transform.SetParent(col.transform);
        //������𖳌��ɂ���
        GetComponent<CircleCollider2D>().enabled = false;
        //�����V�~�����[�V�����𖳌��ɂ���
        GetComponent<Rigidbody2D>().simulated = false;
    }
}
