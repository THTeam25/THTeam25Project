using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_BossAttackManager : MonoBehaviour
{
    //技1
    Stage3_BossAttack01 Attack1;
    //技2
    Stage3_BossAttack02 Attack2;
    //技3
    Stage3_Attack3 Attack3;

    //ループカウント
    int count = 0;

    //ループの間隔
    public float loopTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネント設定
        Attack1 = GetComponent<Stage3_BossAttack01>();
        Attack2 = GetComponent<Stage3_BossAttack02>();
        Attack3 = GetComponent<Stage3_Attack3>();

        //技の遷移
        InvokeRepeating("AttackLoop", 1.0f, loopTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AttackLoop()
    {
        switch (count)
        {
            case 0:
                Attack1.SpawnBullettoPlayer();
                break;
            case 1:
                Attack2.SpawnBullet();
                break;
            case 2:
                Attack3.SpawnMissile();
                break;
        }

        count++;

        count %= 3;
    }

}
