using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムの種類
public enum ItemType
{
    arrow,      //矢
    Key,        //鍵
    life,        //ライフ
}

public class ItemData : MonoBehaviour
{
    public ItemType type;        //アイテムの種類
    public int count = 1;        //アイテム数

    public int arrangeID = 0;    //配置の識別に使う
    void Start()
    {

    }

    
    void Update()
    {
        
    }
}
