using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePileScript : MonoBehaviour
{
    //�߂܂��Ă��������܂ł̎��Ԏ���
    public float disappearTime = 3.0f;

    //�����Ă���\�������܂ł̎��Ԏ���
    public float displayTime = 3.0f;

    //PlayerScript
    private PlayerScript pS;

    //�^�C�}�[�t���O
    private bool timer = false;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerScript
        pS = GameObject.Find("Player").GetComponent<PlayerScript>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(pS.isSeize && !timer)
        {
            timer = true;

            //disappearTime�b��disappear�Ă�
            Invoke("Disapper", disappearTime);
        }
    }

    //�\�������\��
    void Disapper()
    {
        //player�̒��t���O���I�t
        pS.isSeize = false;

        //�^�C�}�[�t���O���I�t
        timer = false;

        //gameObject��A�N�e�B�u
        gameObject.SetActive(false);

        Invoke("Display", displayTime);
    }

    //��\������\��
    void Display()
    {
        //gameObject��A�N�e�B�u
        gameObject.SetActive(true);
    }
}
