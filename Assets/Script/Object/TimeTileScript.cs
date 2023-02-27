using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTileScript : MonoBehaviour
{
    //�߂܂��Ă��������܂ł̎��Ԏ���
    public float disappearTime = 3.0f;

    //�����Ă���\�������܂ł̎��Ԏ���
    public float displayTime = 3.0f;

    //�^�C�}�[�t���O
    private bool timer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Player���G�ꂽ��
        if(collision.gameObject.CompareTag("Player") && !timer)
        {
            timer = true;

            //disappearTime�b�o�ߌ��\��
            Invoke("Disappear",disappearTime);
        }
    }

    //��莞�Ԍo�ߌ��\��
    void Disappear()
    {
        gameObject.SetActive(false);

        //displayTime�o�ߌ�\��
        Invoke("Display",displayTime);
    }

    //��莞�Ԍo�ߌ�\��
    void Display()
    {
        gameObject.SetActive(true);

        timer = false;
    }


}
