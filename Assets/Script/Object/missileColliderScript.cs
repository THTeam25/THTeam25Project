using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Playerとの当たり判定
    private void OnCollisionEnter(Collision collision)
    {
        

        if(collision.gameObject.CompareTag("Player"))
        {
            

            //Playerの体力のスクリプト
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            //Playerへダメージ
            ps.TakeDamage(1);

            //オブジェクト削除
            Destroy(transform.parent.gameObject);
        }
    }
}
