using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBulletScript : MonoBehaviour
{
   
    //速度
    public float speed = 5.0f;
    //寿命
    public float deathTime = 5.0f;
    //プレイヤー狙う場合
    public bool toPlayer;

    //目標地点
    Vector3 bulletVector;
    //発射時間
    float fireTime;

    // Start is called before the first frame update
    void Start()
    {
        if(toPlayer)
        {
            bulletVector = GameObject.Find("Player").transform.position - transform.position;
            Fire();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - fireTime > deathTime)
        {
            Destroy(gameObject);
        }
    }

    void Fire()
    {
        
        bulletVector.Normalize();

        GetComponent<Rigidbody>().AddForce(bulletVector * speed);

        fireTime = Time.time;
    }

    //弾の方向決定
    public void SetBulletVector(Vector3 vec)
    {
        bulletVector = vec;

        Fire();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //当った処理
        if(collision.gameObject.CompareTag("Player"))
        {
            //Playerの体力のスクリプト
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);

            Destroy(gameObject);
        }
        else if(!collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
