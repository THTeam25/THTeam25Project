using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePileScript : MonoBehaviour
{
    //�߂܂��Ă��������܂ł̎��Ԏ���
    public float disappearTime = 3.0f;

    //�����Ă���\�������܂ł̎��Ԏ���
    public float displayTime = 3.0f;

    //������t���O�iFalse�Ȃ�v���C���[�����񂾃^�C�~���O,True�Ȃ�X�^�[�g���j
    public bool bStartr;

    //�ŏ����������Ă��邩�t���O
    public bool bFirstHidden;

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
        if(pS.isSeize && !timer && pS.hitPile == this.gameObject && !bStartr)
        {
            timer = true;

            //disappearTime�b��disappear�Ă�
            Invoke("Disapper", disappearTime);
        }
        else if(bStartr && !timer)
        {
            timer = true;

            //�A�N�e�B�u�ŕ\�����邩��\���ɂ��邩�A��
            if(!bFirstHidden)
            {
                //disappearTime�b��disappear�Ă�
                Invoke("Disapper", disappearTime);
            }
            else
            {


                //gameObject��A�N�e�B�u
                gameObject.SetActive(false);

                Invoke("Display", displayTime);

            }


            
        }
    }

    //�\�������\��
    void Disapper()
    {
        

        if(pS.hitPile == gameObject)
        {
            //player�̒��t���O���I�t
            pS.isSeize = false;

            //Player��hitPile��Null
            pS.hitPile = null;

            //�v���C���[�̏k��߂�
            pS.FinishExtend();

        }
        

        //gameObject��A�N�e�B�u
        gameObject.SetActive(false);

        Invoke("Display", displayTime);
    }

    //��\������\��
    void Display()
    {
        //gameObject��A�N�e�B�u
        gameObject.SetActive(true);

        if(!bFirstHidden)
        {
            //�^�C�}�[�t���O���I�t
            timer = false;
        }
        else
        {
            //disappearTime�b��disappear�Ă�
            Invoke("Disapper", disappearTime);
        }
        
    }
}
