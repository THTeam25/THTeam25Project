using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_BossAttack02 : MonoBehaviour
{
    //���˂���e
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
        //����
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //�e�̈ړ��x�N�g���w��
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, 0, 1));
        //����
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //�e�̈ړ��x�N�g���w��
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, 0, -1));
        //����
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //�e�̈ړ��x�N�g���w��
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, 1, 0));
        //����
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //�e�̈ړ��x�N�g���w��
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, -1, 0));
        //����
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //�e�̈ړ��x�N�g���w��
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, 1, 1));
        //����
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //�e�̈ړ��x�N�g���w��
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, -1, 1));
        //����
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //�e�̈ړ��x�N�g���w��
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, 1, -1));
        //����
        spawnBullet = Instantiate(bullet, transform.position + new Vector3(0, 3, 0), transform.rotation);
        //�e�̈ړ��x�N�g���w��
        spawnBullet.GetComponent<StraightBulletScript>().SetBulletVector(new Vector3(0, -1, -1));
    }
}
