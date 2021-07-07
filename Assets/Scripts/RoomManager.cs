using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoomManager : MonoBehaviour
{
    //static変数
    public static int doorNumber = 0;      //ドアの番号
    
    void Start()
    {
        //プレイヤーキャラクター位置
        //出入口を配列で得る
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Exit");
        for (int i = 0; i < enters.Length; i++)
        {
            GameObject doorObj = enters[i];     //配列から取り出す
            Exit exit = doorObj.GetComponent<Exit>();    //Exitクラスを取得
            if (doorNumber == exit.doorNumber)
            {
                //====ドア番号同じ====
                //プレイヤーキャラクター出入口に移動
                float x = doorObj.transform.position.x;
                float y = doorObj.transform.position.y;
                if (exit.direction == ExitDirection.up)
                {
                    y += 1;
                }
                else if(exit.direction == ExitDirection.right)
                {
                    x += 1;
                }
                else if (exit.direction == ExitDirection.down)
                {
                    y -= 1;
                }
                else if (exit.direction == ExitDirection.left)
                {
                    x -= 1;
                }
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(x, y);
                break;       //ループを抜ける
            }
        }
            
    }
    void Update()
    {
        
    }

    　//シーン移動
     public static void ChangeScene(string scnename, int doornum)
    {
        doorNumber = doornum;      //ドア番号をstatic変数に保存
        SceneManager.LoadScene(scnename);     //シーン移動
    }
}
