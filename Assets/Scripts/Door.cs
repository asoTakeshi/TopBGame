using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int arrangeID = 0;       //配列に識別に使う
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
            //鍵を持っている
            if (ItemKeeper.hasKeys > 0)
            {
                ItemKeeper.hasKeys--;     //鍵を１つ減らす
                Destroy(this.gameObject);   //ドアを開ける（削除する）
            }
        }
    }
}
