using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//出入口の位置
public enum ExitDirection
{
    right,  //右方向
    left,   //左方向
    down,   //下方向
    up,     //上方向
}
public class Exit : MonoBehaviour
{
    public string sceneName = "";     //移動先のs－ン
    public int doorNumber = 0;        //ドア番号
    public ExitDirection direction = ExitDirection.down;    //ドアの位置
   
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            RoomManager.ChangeScene(sceneName, doorNumber);
        }
    }
}
