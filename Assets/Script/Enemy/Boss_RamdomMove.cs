using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_RamdomMove : MonoBehaviour
{
    [SerializeField]
    public bool behavior1Active = false;
    [SerializeField]
    public bool behavior2Active = false;
    [SerializeField]
    public bool behavior3Active = false;
    [SerializeField]
    public bool behavior4Active = false;

    public int stageNo = 0;

    [SerializeField]
    private float timer = 0f;
    [SerializeField]
    private float behaviorDuration = 10f;

    //private int randomBehavior = 0;
    private int startnum;

    private void Start()
    {
        startnum = 0;

    }

    private void Update()
    {

        GameObject cameraChangePoint_Boss = GameObject.Find("CameraChangePoint_Boss");
        CameraSwitcher CS = cameraChangePoint_Boss.GetComponent<CameraSwitcher>();
        if (CS.bossmoveflag == true)
        {
            if (stageNo == 1)
            {
                Stage1Active();
            }

            else if (stageNo == 2)
            {
                Stage2Active();
            }

        }
    }

    private void Stage1Active()
    {

        if (startnum == 0)
        {
            // 挙動1を初期化
            behavior1Active = true;
            startnum = 1;
        }
        // タイマーを更新
        timer += Time.deltaTime;

        // 挙動1を実行
        if (behavior1Active)
        {
            // 2-5秒経ったら挙動2を実行
            float behavior2Activetimer = Random.Range(2.0f, 5.0f);
            if (timer >= behavior2Activetimer)
            {
                behavior2Active = true;

            }
            if (timer >= behaviorDuration)
            {
                behavior1Active = false;
                behavior2Active = false;
                timer = 0f;

                // 挙動3を実行
                behavior3Active = true;
            }
        }
        // 挙動3を実行
        else if (behavior3Active)
        {
            if (timer >= behaviorDuration)
            {
                behavior3Active = false;
                timer = 0f;

                // 挙動1を再開
                behavior1Active = true;
            }
        }
    }
    private void Stage2Active()//2は時間じゃなく、個々のスクリプトで制御
    {

        if (startnum == 0)
        {
            // 挙動1を初期化
            behavior1Active = true;
            startnum = 1;
        }
        // タイマーを更新
        timer += Time.deltaTime;
    }
}

