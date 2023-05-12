using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_BossAttack03 : MonoBehaviour
{
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
        GameObject spawnbullet =  Instantiate(bullet, transform.position + new Vector3(0, 6, 0), transform.rotation);
        int random = Random.Range(0, 2);

        if(random == 0)
        {
            spawnbullet.transform.localScale *= 2;
        }
    }
}
