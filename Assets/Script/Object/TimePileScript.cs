using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePileScript : MonoBehaviour
{
    //捕まってから消えるまでの時間時間
    public float disappearTime = 3.0f;

    //消えてから表示されるまでの時間時間
    public float displayTime = 3.0f;

    //消えるフラグ（Falseならプレイヤーがつかんだタイミング,Trueならスタート時）
    public bool bStartr;

    //最初柱が消えているかフラグ
    public bool bFirstHidden;

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
        if(pS.isSeize && !timer && pS.hitPile == this.gameObject && !bStartr)
        {
            timer = true;

            //disappearTime秒後disappear呼ぶ
            Invoke("Disapper", disappearTime);
        }
        else if(bStartr && !timer)
        {
            timer = true;

            //アクティブで表示するか非表示にするか帰る
            if(!bFirstHidden)
            {
                //disappearTime秒後disappear呼ぶ
                Invoke("Disapper", disappearTime);
            }
            else
            {


                //gameObject非アクティブ
                gameObject.SetActive(false);

                Invoke("Display", displayTime);

            }


            
        }
    }

    //表示から非表示
    void Disapper()
    {
        

        if(pS.hitPile == gameObject)
        {
            //playerの柱フラグをオフ
            pS.isSeize = false;

            //PlayerのhitPileをNull
            pS.hitPile = null;

            //プレイヤーの縮を戻す
            pS.FinishExtend();

        }
        

        //gameObject非アクティブ
        gameObject.SetActive(false);

        Invoke("Display", displayTime);
    }

    //非表示から表示
    void Display()
    {
        //gameObject非アクティブ
        gameObject.SetActive(true);

        if(!bFirstHidden)
        {
            //タイマーフラグをオフ
            timer = false;
        }
        else
        {
            //disappearTime秒後disappear呼ぶ
            Invoke("Disapper", disappearTime);
        }
        
    }
}
