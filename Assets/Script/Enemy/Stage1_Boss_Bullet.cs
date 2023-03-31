using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Boss_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Playerの体力のスクリプト
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);
            Destroy(gameObject); //自身を削除
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject); //自身を削除
        }
    }
}
