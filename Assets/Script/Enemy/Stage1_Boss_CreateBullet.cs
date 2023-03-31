using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Boss_CreateBullet : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField]
    [Tooltip("生成する範囲A")]//カーソルを合わせた際説明表示
    private Transform Range_leftup;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform Range_rightdown;

    // 経過時間
    [Tooltip("弾を生成する間隔")]
    public float bulletwait;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = bulletwait;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //挙動を変えるスクリプト取得
        GameObject manager_RandomBullet = GameObject.Find("Manager_RandomBullet");
        Stage1_Boss_RamdomBullet S1B_BR = manager_RandomBullet.GetComponent<Stage1_Boss_RamdomBullet>();

        if (S1B_BR.behavior1Active == true)
        {
            time -= Time.deltaTime;

            if (time <= 0.0f)//timeが0になったら
            {
                // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                float y = Random.Range(Range_leftup.position.y, Range_rightdown.position.y);
                // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                float z = Random.Range(Range_leftup.position.z, Range_rightdown.position.z);

                // GameObjectを上記で決まったランダムな場所に生成
                Instantiate(bullet, new Vector3(0.0f, y, z), bullet.transform.rotation);

                // 経過時間リセット
                time = bulletwait;
            }
        }
    }
}
