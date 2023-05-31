using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraSonicBulletScript : MonoBehaviour
{
    float startTime; //発射時刻
    public float Timer = 0.5f; //経過時刻
    public float upsize = 0.5f;
    //エネミーのリジットボディ
    private Rigidbody enemyRb;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        startTime = Time.time; //発射された時刻を覚えておく
        transform.LookAt(player.transform);//プレイヤーの方向を向き続ける
    }

    // Update is called once per frame
    void Update()
    {
        

        this.transform.localScale += new Vector3(0, upsize, 0);

        if (startTime + Timer < Time.time) //発射からTimer分の時間経ったら
        {
            Destroy(gameObject); //自身を削除
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Playerの体力のスクリプト
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);

            //自身を削除
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //自身を削除
            Destroy(gameObject);

        }
    }
}
