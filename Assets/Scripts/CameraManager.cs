using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            //�v���C���[�̈ʒu�ƘA��������
            transform.position = new Vector3(player.transform.position.x,
                                player.transform.position.y, - 10);
        }
    }
}
