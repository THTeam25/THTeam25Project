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
        //InvokeRepeating("Spawnmissile",3.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //missile発射
    public void Spawnmissile()
    {
        Instantiate(missile, transform.position, Quaternion.identity);
    }
}
