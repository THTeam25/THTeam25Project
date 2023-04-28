using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    //ミサイルの移動速度
    public float speed = 5.0f;

    //ターゲットオブジェクト
    GameObject target;
    //発射時間
    float fireTime;

    public float deathTime = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");

        fireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Quaternion(回転値)を取得
        Quaternion quaternion = Quaternion.LookRotation(target.transform.position - transform.position);
        // 算出した回転値をこのゲームオブジェクトのrotationに代入
        transform.rotation = quaternion;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(Time.time - fireTime > deathTime)
        {
            Destroy(gameObject);
        }
    }
}
