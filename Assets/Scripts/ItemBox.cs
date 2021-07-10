using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Sprite openImage;         //�J�����摜
    public GameObject itemPrefab;    //�o�Ă���A�C�e���̃v���n�u
    public bool isClosed = true;     //true=�܂��Ă���@false=�J���Ă���
    public int arrangeID = 0;        //�z�u�̎��ʂɎg��
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    /// <summary>
    /// �ڐG����
    /// </summary>
    /// <param name="col"></param>

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(isClosed && col.gameObject.tag == "Player")
        {
            //�����܂��Ă����ԂŃv���C���[�ɐڐG
            GetComponent<SpriteRenderer>().sprite = openImage;
            isClosed = false;    //�J���Ă��Ԃɂ���
            if(itemPrefab != null)
            {
                //�A�C�e�����v���n�u������
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
