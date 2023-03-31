using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーに弾を打つ敵用の索敵判定プログラム
public class CheckShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //弾を撃つスクリプト取得
            EnemyShotScript ess = transform.root.gameObject.GetComponent<EnemyShotScript>();


            //発射開始
            ess.SetShot(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //弾を撃つスクリプト取得
            EnemyShotScript ess = transform.root.gameObject.GetComponent<EnemyShotScript>();


            //追跡終了
            ess.SetShot(false);
        }
    }
}
