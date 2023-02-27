using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTileScript : MonoBehaviour
{
    //捕まってから消えるまでの時間時間
    public float disappearTime = 3.0f;

    //消えてから表示されるまでの時間時間
    public float displayTime = 3.0f;

    //タイマーフラグ
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
        //Playerが触れたら
        if(collision.gameObject.CompareTag("Player") && !timer)
        {
            timer = true;

            //disappearTime秒経過後非表示
            Invoke("Disappear",disappearTime);
        }
    }

    //一定時間経過後非表示
    void Disappear()
    {
        gameObject.SetActive(false);

        //displayTime経過後表示
        Invoke("Display",displayTime);
    }

    //一定時間経過後表示
    void Display()
    {
        gameObject.SetActive(true);

        timer = false;
    }


}
