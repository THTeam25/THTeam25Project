using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBulletScript : MonoBehaviour
{
   
    //速度
    public float speed = 5.0f;
    //寿命
    public float deathTime = 5.0f;

    //目標地点
    Vector3 goalPosition;
    //発射時間
    float fireTime;

    // Start is called before the first frame update
    void Start()
    {
        goalPosition = GameObject.Find("Player").transform.position;

        GetComponent<Rigidbody>().AddForce((goalPosition - transform.position) * speed);

        fireTime = Time.time;

        Debug.Log("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - fireTime > deathTime)
        {
            Destroy(gameObject);
        }
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
