using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_Attack3 : MonoBehaviour
{
    //ミサイルオブジェクト
    public GameObject missile;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnMissile",3.0f,10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //missile発射
    public void SpawnMissile()
    {
        Instantiate(missile, transform.position, Quaternion.identity);
    }
}
