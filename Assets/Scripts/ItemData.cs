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
}