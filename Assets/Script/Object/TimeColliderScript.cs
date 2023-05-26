using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeColliderScript : MonoBehaviour
{
    public bool issound1 = false;//�Ȃ炷���ǂ���
    [SerializeField]
    private float starttimer = 0.0f;//�J�n�܂ł̎���
    [SerializeField]
    private float displaytime = 5.0f;//�\������
    [SerializeField]
    private float disappeartime = 5.0f;//��\���ɂ��鎞��

    private float time;//����

    private bool startflag;
    private bool soundflag;//�Ȃ炷���ǂ���
    private int countnum;//�Ȃ炷���ǂ���
    [SerializeField]
    private bool isdisplay;//��ɕ\�����邩


    private GameObject soundManager;
    private GameObject timeCollider_Master;
    [SerializeField]
    private AudioClip clip1;//�^�C�}�[��

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        countnum = 0;
        startflag = false;
        soundflag = false;
        soundManager = GameObject.Find("SoundManager");

        timeCollider_Master = GameObject.Find("TimeCollider_Master");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;



        //�J�n���ԂɂȂ�����
        if (time >= starttimer && startflag == false)
        {
            startflag = true;//�J�n
            time = 0.0f;
        }

        else if(startflag == true)
        {
            if(isdisplay == true)//�\������ꍇ
            {
                if (time >= 0.0f && issound1 == true && soundflag == false && countnum == 0)
                {
                    soundflag = true;
                    countnum = 1;
                }
                if (time >= displaytime)
                {
                    isdisplay = false;//��\��
                    time = 0.0f;
                }
                if (issound1 == true && timeCollider_Master.GetComponent<TimeColliderSoundScript>().issound == true && soundflag == true)
                {
                    soundManager.GetComponent<SoundManagerScript>().PlaySe(clip1);
                    soundflag = false;
                    countnum = 0;
                }
            }

            else if(isdisplay == false)
            {
                if (time >= disappeartime)
                {
                    isdisplay = true;//�\��
                    time = 0.0f;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pile"))
        {
            if (startflag == true)
            {
                if (isdisplay == true)
                {
                    other.GetComponent<Renderer>().enabled = true;//�\��
                }
                else if (isdisplay == false)
                {
                    other.GetComponent<Renderer>().enabled = false;//��\��
                }
            }
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (startflag == true)
            {
                if (isdisplay == true)
                {
                    other.GetComponent<Renderer>().enabled = true;//�\��
                }
                else if (isdisplay == false)
                {
                    other.GetComponent<Renderer>().enabled = false;//��\��
                }
            }
        }
    }
}
