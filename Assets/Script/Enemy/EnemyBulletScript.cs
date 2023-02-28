using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    float startTime; //発射時刻
    public float Timer = 0.5f; //経過時刻
    //エネミーのリジットボディ
    private Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; //発射された時刻を覚えておく
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime + Timer < Time.time) //発射から0.5秒経ったら
        {
            Destroy(gameObject); //自身を削除
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Playerの体力のスクリプト
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);

            //自身を削除
            Destroy(gameObject);
        }
    }
}
