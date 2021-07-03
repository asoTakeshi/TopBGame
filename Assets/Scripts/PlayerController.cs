using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移動スピード
    public float speed = 3.0f;
    //アニメーション名
    public string upAnime = "PlayerUp";          //上向き
    public string downAnime = "PlayerDown";      //下向き
    public string rightAnime = "PlayerRight";    //上向き
    public string leftAnime = "PlayerLeft";      //左向き
    public string deadAnime = "PlayerDead";      //死亡
    //現在のアニメーション
    string nowAnimation = "";
    //以前のアニメーション
    string oldAnimation = "";

    float axisH;           //横軸値(-1.0 ～ 0.0 ～ 1.0)
    float axisV;           //縦軸値(-1.0 ～ 0.0 ～ 1.0)
    public float angleZ = -90.0f;      //回転軸
    Rigidbody2D rb;         //Rigidbody2D
    bool isMoving = false;  //移動中フラグ
    //ダメージ対応
    public static int hp = 3;       //playerのHP
    public static string gameState;  //ゲームの状態
    bool inDamage = false;           //ダメージ中フラグ

    void Start()
    {
        //Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
        //アニメーション
        oldAnimation = downAnime;
        //ゲームの状態をプレイ中にする
        gameState = "playing";
    }
    void Update()
    {
        //ゲーム中以外とダメージ中は何もしない
        if (gameState != "playing" || inDamage)
        {
            return;
        }
        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");   //左右キー入力
            axisV = Input.GetAxisRaw("Vertical");     //上下キー入力
        }
        //キー入力から移動角度を求める
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);
        //移動角度から向いている方向とアニメーション更新
        if (angleZ >= -45 && angleZ < 45)
        {
            //右向き
            nowAnimation = rightAnime;
        }
        else if (angleZ >= 45 && angleZ <= 135)
        {
            //上向き
            nowAnimation = upAnime;
        }
        else if (angleZ >= -135 && angleZ <= -45)
        {
            //下向き
            nowAnimation = downAnime;
        }
        else
        {
            //左向き
            nowAnimation = leftAnime;
        }
        //アニメーション切り替える
        if (nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            GetComponent<Animator>().Play(nowAnimation);
        }
    }
    private void FixedUpdate()
    {
        //ゲーム中以外は何もしない
        if (gameState != "playing")
        {
            return;
        }
        if (inDamage)
        {
            //ダメージ中点滅させる
            float val = Mathf.Sin(Time.time * 50);
            Debug.Log(val);
            if(val > 0)
            {
                //スプライトを表示
                gameObject.GetComponent<SpriteRenderer>().enabled = true;

            }
            else
            {
                //スプライトを非表示
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            return;      //ダメージ中は操作による移動をさせない
        }
        //移動速度を更新する
        rb.velocity = new Vector2(axisH, axisV) * speed;
    }
    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
    /// <summary>
    /// p1からp2の角度を返す
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if (axisH != 0 || axisV != 0)
        {
            //移動中であれば角度を更新する
            //p1からp2への差分(原点を0にする)
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            //アークタンジェント2次関数で角度を求める
            float rad = Mathf.Atan2(dy, dx);
            //ラジアンを度に変換して返す
            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            //停止中であれば以前の角度を維持
            angle = angleZ;
        }
        return angle;
    }

    /// <summary>
    /// 接触（物理）
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            GetDamage(col.gameObject);
        }

    }

    /// <summary>
    /// ダメージ
    /// </summary>
    /// <param name="enemy"></param>
    void GetDamage(GameObject enemy)
    {
        if (gameState == "playing")
        {
            hp--;     //HPを減らす
            Debug.Log("Player HP=" + hp);
            if(hp > 0)
            {
                //移動停止
                rb.velocity = new Vector2(0, 0);
                //敵キャラの反対方向にヒットバックさせる
                Vector3 v = (transform.position - enemy.transform.position).normalized;
                rb.AddForce(new Vector2(v.x * 4, v.y * 4), ForceMode2D.Impulse);
                //ダメージフラグON
                inDamage = true;
                Invoke("DamageEnd", 0.25f);
            }
            else
            {
                //ゲームオーバー
                GameOver();
            }
        }
    }
    /// <summary>
    /// ダメージ終了
    /// </summary>
    void DamageEnd()
    {
        //ダメージフラグOFF
        inDamage = false;
        //スプライトを元に戻す
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    void GameOver()
    {
        Debug.Log("ゲームオーバー");
        gameState = "gameover";
        //===================
        //ゲームオーバー演出
        //===================
        //プレイヤー当たりを消す
        GetComponent<CircleCollider2D>().enabled = false;
        //移動停止
        rb.velocity = new Vector2(0, 0);
        //重力を戻してプレイヤーを上に少し跳ね上げる演出
        rb.gravityScale = 1;
        rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        //アニメーションを切り替える
        GetComponent<Animator>().Play(deadAnime);
        //1秒後にプレイヤーキャラクターを消す
        Destroy(gameObject, 1.0f);
    }
}
