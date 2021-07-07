using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�o�����̈ʒu
public enum ExitDirection
{
    right,  //�E����
    left,   //������
    down,   //������
    up,     //�����
}
public class Exit : MonoBehaviour
{
    public string sceneName = "";     //�ړ����s�|��
    public int doorNumber = 0;        //�h�A�ԍ�
    public ExitDirection direction = ExitDirection.down;    //�h�A�̈ʒu
   
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
