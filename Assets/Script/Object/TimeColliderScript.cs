using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeColliderScript : MonoBehaviour
{
    [SerializeField]
    private float starttimer = 0.0f;//�J�n�܂ł̎���
    [SerializeField]
    private float displaytime = 5.0f;//�\������
    [SerializeField]
    private float disappeartime = 5.0f;//��\���ɂ��鎞��

    private float time;//����


    private bool startflag;
    [SerializeField]
    private bool isdisplay;//��ɕ\�����邩

    [SerializeField]
    private bool isfade;//�������ɂ��邩

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        startflag = false;
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
                if (time >= displaytime)
                {
                    isdisplay = false;//��\��
                    time = 0.0f;
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
        if (other.gameObject.CompareTag("Pile")|| other.gameObject.CompareTag("Enemy"))
        {
            if (startflag == true)
            {
                if (isdisplay == true)
                {
                    other.GetComponent<Renderer>().material.color = new Color(other.GetComponent<Renderer>().material.color.r, other.GetComponent<Renderer>().material.color.g, other.GetComponent<Renderer>().material.color.b, 1.0f);
                    other.GetComponent<Renderer>().enabled = true;//�\��
                }
                else if (isdisplay == false)
                {
                    if(isfade == false)
                    {
                        other.GetComponent<Renderer>().enabled = false;//��\��
                    }
                    else if (isfade == true)
                    {
                        other.GetComponent<Renderer>().material.color = new Color(other.GetComponent<Renderer>().material.color.r, other.GetComponent<Renderer>().material.color.g, other.GetComponent<Renderer>().material.color.b, 0.5f);
                    }
                }
            }
        }
    }
}
