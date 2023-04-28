using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_Attack3 : MonoBehaviour
{
    //ミサイルオブジェクト
    public GameObject missile;

    //ターゲット
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnMissile",3.0f,10.0f);

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //missile発射
    public void SpawnMissile()
    {
        Vector3 pos = player.transform.position - transform.position;
        pos.Normalize();
        Instantiate(missile, transform.position + (pos * 3), Quaternion.identity);
    }
}
