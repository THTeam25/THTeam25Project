using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeColliderScript : MonoBehaviour
{
    [SerializeField]
    private float starttimer = 0.0f;//開始までの時間
    [SerializeField]
    private float displaytime = 5.0f;//表示時間
    [SerializeField]
    private float disappeartime = 5.0f;//非表示にする時間

    private float time;//時間


    private bool startflag;
    [SerializeField]
    private bool isdisplay;//先に表示するか

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        startflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //開始時間になったら
        if (time >= starttimer && startflag == false)
        {
            startflag = true;//開始
            time = 0.0f;
        }

        else if(startflag == true)
        {
            if(isdisplay == true)//表示する場合
            {
                if (time >= displaytime)
                {
                    isdisplay = false;//非表示
                    time = 0.0f;
                }
            }
            else if(isdisplay == false)
            {
                if (time >= disappeartime)
                {
                    isdisplay = true;//表示
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
                    other.GetComponent<Renderer>().enabled = true;//表示
                }
                else if (isdisplay == false)
                {
                    other.GetComponent<Renderer>().enabled = false;//非表示
                }
            }
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (startflag == true)
            {
                if (isdisplay == true)
                {
                    other.GetComponent<Renderer>().enabled = true;//表示
                }
                else if (isdisplay == false)
                {
                    other.GetComponent<Renderer>().enabled = false;//非表示
                }
            }
        }
    }
}
