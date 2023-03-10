using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;


    public float bulletwait = 1.0f;//弾の発射間隔
    public float bulletspeed = 10.0f;

    private float time;
    private bool isShot = false;//発射フラグ

    //エネミーのリジットボディ
    private Rigidbody enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        time = bulletwait;
    }

    // Update is called once per frame
    void Update()
    {
 

        Shot();
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

    void Shot()
    {
        if (isShot)//プレイヤーがトリガーと接触したら
        {
            transform.LookAt(player.transform);//プレイヤーの方向を向き続ける
            time -= Time.deltaTime;

            if (time <= 0)//タイムが0になったら
            {
                //弾を出現させる地点
                Vector3 vec = transform.position + transform.forward * 0.5f; //キャラクターの位置より少し前
                var shot = Instantiate(bullet, vec, Quaternion.identity);//生成
                shot.GetComponent<Rigidbody>().velocity = transform.forward.normalized * bulletspeed;

                time = bulletwait;
            }
        }
    }

    //発射フラグ設定
    public void SetShot(bool f)
    {
        isShot = f;
    }
}
