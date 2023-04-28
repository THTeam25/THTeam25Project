using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Boss_PlayerAttack : MonoBehaviour
{
    public float speed = 3f;

    private Transform player;
    private bool isMoving;
    private int startnum;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        startnum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject manager_Stage2RandomMove = GameObject.Find("Manager_Stage2RandomMove");
        Boss_RamdomMove BRM = manager_Stage2RandomMove.GetComponent<Boss_RamdomMove>();
        if (BRM.behavior2Active == true)
        {
            if (startnum == 0)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
                Vector3 playerPos = player.position;
                playerPos.y = transform.position.y;
                transform.LookAt(playerPos);
                startnum = 1;
            }
            if (isMoving)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                direction.y = 0;
                direction.x = 0;
                transform.Translate(direction * speed * Time.deltaTime, Space.World);  
            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isMoving)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();
                ps.TakeDamage(1);
                isMoving = false;//動きを止める
            }
            if (collision.gameObject.CompareTag("Screen"))
            {//スクリーンに当たったら
             //Bossの体力のスクリプト
                GameObject manager_Stage2HealthManager = GameObject.Find("Manager_Stage2HealthManager ");
                Boss_HealthManager boss_HealthManager = manager_Stage2HealthManager.GetComponent<Boss_HealthManager>();
                boss_HealthManager.TakeDamage(1);//ボスの体力を減らす
                isMoving = false;//動きを止める
            }
        }
       
    }
}
