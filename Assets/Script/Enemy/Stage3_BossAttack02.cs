using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_BossAttack02 : MonoBehaviour
{
    //発射する弾
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void SpawnBullet()
    {
        GameObject spawnBullet;
        //生成
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //弾の移動ベクトル指定
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, 0, 1));
        //生成
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //弾の移動ベクトル指定
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, 0, -1));
        //生成
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //弾の移動ベクトル指定
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, 1, 0));
        //生成
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //弾の移動ベクトル指定
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, -1, 0));
        //生成
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //弾の移動ベクトル指定
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, 1, 1));
        //生成
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //弾の移動ベクトル指定
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, -1, 1));
        //生成
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //弾の移動ベクトル指定
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, 1, -1));
        //生成
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //弾の移動ベクトル指定
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, -1, -1));
    }
}
