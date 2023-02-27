using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePileScript : MonoBehaviour
{
    //捕まってから消えるまでの時間時間
    public float disappearTime = 3.0f;

    //消えてから表示されるまでの時間時間
    public float displayTime = 3.0f;

    //PlayerScript
    private PlayerScript pS;

    //タイマーフラグ
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

            //disappearTime秒後disappear呼ぶ
            Invoke("Disapper", disappearTime);
        }
    }

    //表示から非表示
    void Disapper()
    {
        //playerの柱フラグをオフ
        pS.isSeize = false;

        //タイマーフラグをオフ
        timer = false;

        //gameObject非アクティブ
        gameObject.SetActive(false);

        Invoke("Display", displayTime);
    }

    //非表示から表示
    void Display()
    {
        //gameObject非アクティブ
        gameObject.SetActive(true);
    }
}
