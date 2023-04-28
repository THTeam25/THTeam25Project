using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Boss_Tackle : MonoBehaviour
{
    public Transform playerTransform;  // プレイヤーのTransform
    public Transform targetTransform;  // 目的地のTransform
    public float playerSpeed = 5f;  // プレイヤーの座標までの移動スピード
    public float targetSpeed = 2f;  // 目的地までの移動スピード
    public float timer = 3.0f;

    public bool reachedPlayer = false;  // プレイヤーの座標に到達したかどうか
    public bool reachedTarget = false;  // 目的地に到達したかどうか

    private float time = 0.0f;
    private float countnum;
    private void Start()
    {
        countnum = 0;
    }

    private void Update()
    {
        GameObject manager_Stage2RandomMove = GameObject.Find("Manager_Stage2RandomMove");
        Boss_RamdomMove BRM = manager_Stage2RandomMove.GetComponent<Boss_RamdomMove>();
        if (BRM.behavior3Active == true)
        {
            if(countnum == 0)
            {
                time = timer;
                countnum = 1;
            }

            time -= Time.deltaTime;

            if (!reachedPlayer)  // プレイヤーの座標に到達していない場合
            {
                float step = playerSpeed * Time.deltaTime;  // 移動距離を計算する
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, step);  // プレイヤーの座標に向かって移動する

                if (transform.position == playerTransform.position)  // プレイヤーの座標に到達した場合
                {
                    reachedPlayer = true;  // 到達フラグを立てる
                }
                if(time <= 0.0f)
                {
                    reachedPlayer = true;//到達してないけどフラグ立てる
                }
            }

            else if (!reachedTarget)  // 目的地に到達していない場合
            {
                float step = targetSpeed * Time.deltaTime;  // 移動距離を計算する
                transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, step);  // 目的地に向かって移動する

                if (transform.position == targetTransform.position)  // 目的地に到達した場合
                {
                    reachedTarget = true;  // 到達フラグを立てる
                }
            }
            if(reachedTarget)
            {
                BRM.behavior3Active = false;
                BRM.behavior2Active = true;
                countnum = 0;
                reachedTarget = false;
                reachedPlayer = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Playerの体力のスクリプト
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);


        }
    }
}

