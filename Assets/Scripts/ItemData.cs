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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            if (type == ItemType.Key)
            {
                //カギ
                ItemKeeper.hasKeys += 1;
            }
            else if (type == ItemType.arrow)
            {
                //矢
                ArrowShoot shoot = col.gameObject.GetComponent<ArrowShoot>();
                ItemKeeper.hasArrows += count;
            }
            else if (type == ItemType.life)
            {
                //ライフ
                if (PlayerController.hp < 3)
                {
                    //HPが３以下の場合加算する
                    PlayerController.hp++;
                }
            }
            //+++++アイテム取得演出　+++++
            //当たりを消す
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //アイテムのRigidbody2Dを取ってくる
            Rigidbody2D itemBody = GetComponent<Rigidbody2D>();
            //重力を戻す
            itemBody.gravityScale = 2.5f;
            //上に少し跳ね上げる演出
            itemBody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            //0.5秒後に削除
            Destroy(gameObject, 0.5f);
        }  
    }
}
