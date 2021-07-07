using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoomManager : MonoBehaviour
{
    //static�ϐ�
    public static int doorNumber = 0;      //�h�A�̔ԍ�
    
    void Start()
    {
        //�v���C���[�L�����N�^�[�ʒu
        //�o������z��œ���
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Exit");
        for (int i = 0; i < enters.Length; i++)
        {
            GameObject doorObj = enters[i];     //�z�񂩂���o��
            Exit exit = doorObj.GetComponent<Exit>();    //Exit�N���X���擾
            if (doorNumber == exit.doorNumber)
            {
                //====�h�A�ԍ�����====
                //�v���C���[�L�����N�^�[�o�����Ɉړ�
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
                break;       //���[�v�𔲂���
            }
        }
            
    }
    void Update()
    {
        
    }

    �@//�V�[���ړ�
     public static void ChangeScene(string scnename, int doornum)
    {
        doorNumber = doornum;      //�h�A�ԍ���static�ϐ��ɕۑ�
        SceneManager.LoadScene(scnename);     //�V�[���ړ�
    }
}
