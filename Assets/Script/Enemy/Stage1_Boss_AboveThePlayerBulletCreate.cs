using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Boss_AboveThePlayerBulletCreate : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField]
    [Tooltip("プレイヤー")]//カーソルを合わせた際説明表示
    private Transform Player;

    [SerializeField]
    [Tooltip("生成する範囲Aの左上のコライダー")]//カーソルを合わせた際説明表示
    private Transform RangeA_leftup;

    [SerializeField]
    [Tooltip("生成する範囲Aの右下のコライダー")]
    private Transform RangeA_rightdown;

    [SerializeField]
    [Tooltip("生成する範囲Bの左上のコライダー")]//カーソルを合わせた際説明表示
    private Transform RangeB_leftup;

    [SerializeField]
    [Tooltip("生成する範囲Bの右下のコライダー")]
    private Transform RangeB_rightdown;

    // 経過時間
    [Tooltip("弾を生成する間隔")]
    public float bulletwait;

    private float time;
    

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //挙動を変えるスクリプト取得
        GameObject manager_RandomBullet = GameObject.Find("Manager_RandomBullet");
        Boss_RamdomMove S1B_BR = manager_RandomBullet.GetComponent<Boss_RamdomMove>();

        if (S1B_BR.behavior2Active == true)
        {
            time -= Time.deltaTime;

            //左の範囲内にプレイヤーが入っていたら
            if (RangeA_leftup.position.z <= Player.position.z && Player.position.z <= RangeA_rightdown.position.z)
            {
                if (time <= 0.0f)//timeが0になったら
                {
                    // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                    float y = Random.Range(RangeA_leftup.position.y, RangeA_rightdown.position.y);
                    // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                    float z = Player.position.z;

                    // GameObjectを上記で決まったランダムな場所に生成
                    GameObject instance = Instantiate(bullet, new Vector3(0.0f, y, z), bullet.transform.rotation);

                    // 赤色に変更する
                    instance.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

                    // 経過時間リセット
                    time = bulletwait;
                }
            }
            //右の範囲内にプレイヤーが入っていたら
            if (RangeB_leftup.position.z <= Player.position.z && Player.position.z <= RangeB_rightdown.position.z)
            {
                if (time <= 0.0f)//timeが0になったら
                {
                    // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                    float y = Random.Range(RangeB_leftup.position.y, RangeB_rightdown.position.y);
                    // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                    float z = Player.position.z;


                    // GameObjectを上記で決まったランダムな場所に生成
                    GameObject instance = Instantiate(bullet, new Vector3(0.0f, y, z), bullet.transform.rotation);

                    // 赤色に変更する
                    instance.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

                    // 経過時間リセット
                    time = bulletwait;
                }

            }
        }
        



    }
}
