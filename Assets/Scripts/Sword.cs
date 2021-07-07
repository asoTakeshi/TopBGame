using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject swordPrefab;             //剣のプレハブ
    bool inAttack = false;                   //攻撃中フラグ
    GameObject swordObj;
    void Start()
    {
        //剣をプレイヤーキャラクターに配置
        Vector3 pos = transform.position;
        swordObj = Instantiate(swordPrefab, pos, Quaternion.identity);
        swordObj.transform.SetParent(transform);  //剣の親にプレイヤーキャラクターを設定する
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire3")))
        {
            //攻撃キーが押された
            Attack();
        }
    }
    /// <summary>
    /// 攻撃
    /// </summary>
    public void Attack()
    {
        //攻撃中ではない
        if (inAttack == false)
        {
            //ItemKeeper.hasArrows > 0
            //ItemKeeper.hasArrows -= 1;    //矢を減らす
            inAttack = true;       //攻撃フラグを立てる
            //矢を撃つ
            PlayerController playerCnt = GetComponent<PlayerController>();
            //float angleZ = playerCnt.angleZ;     //回転角度
            //矢のゲームオブジェクトを作る（進行方向に回転)
           // Quaternion r = Quaternion.Euler(0, 0, angleZ);
            //GameObject arrowObj = Instantiate(arrowPrefab, transform.position, r);
            //矢を発射するベクトルを作る
           // float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
           // float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
            //Vector3 v = new Vector3(x, y) * shootSpeed;
            //矢に力を加える
           // Rigidbody2D rb = arrowObj.GetComponent<Rigidbody2D>();
           // rb.AddForce(v, ForceMode2D.Impulse);
            //攻撃フラグをおろす遅延行動
            //Invoke("StopAttack", shootDelay);
        }
    }
    /// <summary>
    /// 攻撃停止
    /// </summary>
    public void StopAttack()
    {
        inAttack = false;    //攻撃フラグをおろす
    }
}
