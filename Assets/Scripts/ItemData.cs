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
        }
    }
}
