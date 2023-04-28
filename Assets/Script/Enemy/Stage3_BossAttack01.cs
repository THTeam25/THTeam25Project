using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_BossAttack01 : MonoBehaviour
{
    //”­ŽË‚·‚é’e
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBullet()
    {
        Instantiate(bullet,transform.position + new Vector3(0,3,0),transform.rotation);
    }
}
