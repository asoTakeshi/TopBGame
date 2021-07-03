using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float deleteTime = 2;    //削除時間
    void Start()
    {
        Destroy(gameObject, deleteTime);     //一定時間で消す
    }

    
    void Update()
    {
        
    }
    //ゲームオブジェクトに接触
    private void OnCollisionEnter2D(Collision2D col)
    {
        //接触したゲームオブジェクトの子にする
        transform.SetParent(col.transform);
        //当たりを無効にする
        GetComponent<CircleCollider2D>().enabled = false;
        //物理シミュレーションを無効にする
        GetComponent<Rigidbody2D>().simulated = false;
    }
}
