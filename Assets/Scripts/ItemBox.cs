using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public Sprite openImage;         //開いた画像
    public GameObject itemPrefab;    //出てくるアイテムのプレハブ
    public bool isClosed = true;     //true=閉まっている　false=開いている
    public int arrangeID = 0;        //配置の識別に使う
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    /// <summary>
    /// 接触物理
    /// </summary>
    /// <param name="col"></param>

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(isClosed && col.gameObject.tag == "Player")
        {
            //箱が閉まっている状態でプレイヤーに接触
            GetComponent<SpriteRenderer>().sprite = openImage;
            isClosed = false;    //開いてる状態にする
            if(itemPrefab != null)
            {
                //アイテムをプレハブから作る
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
