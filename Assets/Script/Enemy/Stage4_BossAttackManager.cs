using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_BossAttackManager : MonoBehaviour
{
    Stage4_BossAttack01 attack1;
    Stage4_BossAttack02 attack2;
    Stage4_BossAttack03 attack3;
    CameraSwitcher cS;
    bool start = false;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        cS = GameObject.Find("CameraChangePoint_Stage1_Boss").GetComponent<CameraSwitcher>();

        attack1 = GetComponent<Stage4_BossAttack01>();
        attack2 = GetComponent<Stage4_BossAttack02>();
        attack3 = GetComponent<Stage4_BossAttack03>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cS.bossmoveflag && !start)
        {
            start = true;

            InvokeRepeating("Attack",0,6.0f);
        }
    }

    void Attack()
    {
        switch (count)
        {
            case 0:
                attack1.ChangePilePos();
                break;
            case 1:
                attack2.DigAttack();
                break;
            case 2:
                attack3.SpawnBullet();
                break;
        }

        count++;

        count %= 3;

    }
}
