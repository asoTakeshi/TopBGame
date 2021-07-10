using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�A�C�e���̎��
public enum ItemType
{
    arrow,      //��
    Key,        //��
    life,        //���C�t
}

public class ItemData : MonoBehaviour
{
    public ItemType type;        //�A�C�e���̎��
    public int count = 1;        //�A�C�e����

    public int arrangeID = 0;    //�z�u�̎��ʂɎg��
    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            if (type == ItemType.Key)
            {
                //�J�M
                ItemKeeper.hasKeys += 1;
            }
            else if (type == ItemType.arrow)
            {
                //��
                ArrowShoot shoot = col.gameObject.GetComponent<ArrowShoot>();
                ItemKeeper.hasArrows += count;
            }
            else if (type == ItemType.life)
            {
                //���C�t
                if (PlayerController.hp < 3)
                {
                    //HP���R�ȉ��̏ꍇ���Z����
                    PlayerController.hp++;
                }
            }
            //+++++�A�C�e���擾���o�@+++++
            //�����������
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //�A�C�e����Rigidbody2D������Ă���
            Rigidbody2D itemBody = GetComponent<Rigidbody2D>();
            //�d�͂�߂�
            itemBody.gravityScale = 2.5f;
            //��ɏ������ˏグ�鉉�o
            itemBody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            //0.5�b��ɍ폜
            Destroy(gameObject, 0.5f);
        }  
    }
}
