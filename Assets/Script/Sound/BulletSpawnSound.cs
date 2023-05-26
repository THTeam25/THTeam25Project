using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnSound : MonoBehaviour
{
    //サウンド
    SoundManagerScript sMS;
    public AudioClip spawnSound;

    // Start is called before the first frame update
    void Start()
    {
        //サウンドマネージャー取得
        sMS = GameObject.Find("SoundManager").GetComponent<SoundManagerScript>();

        sMS.PlaySe(spawnSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
