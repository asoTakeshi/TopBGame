using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int arrangeID = 0;       //�z��Ɏ��ʂɎg��
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
            //���������Ă���
            if (ItemKeeper.hasKeys > 0)
            {
                ItemKeeper.hasKeys--;     //�����P���炷
                Destroy(this.gameObject);   //�h�A���J����i�폜����j
            }
        }
    }
}
