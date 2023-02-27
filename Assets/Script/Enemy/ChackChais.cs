using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//追跡する敵用の追跡判定プログラム
public class ChackChais : MonoBehaviour
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
        if(other.gameObject.CompareTag("Player"))
        {
            //追跡エネミースクリプト取得
            ChaisEnemyScript cs = transform.root.gameObject.GetComponent<ChaisEnemyScript>();

            //PlayerObject設定
            cs.SetPlayer(other.gameObject);

            //追跡開始
            cs.SetChais(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //追跡エネミースクリプト取得
            ChaisEnemyScript cs = transform.root.gameObject.GetComponent<ChaisEnemyScript>();

            //PlayerObject設定
            cs.SetPlayer(null);

            //追跡終了
            cs.SetChais(false);
        }
    }
}
