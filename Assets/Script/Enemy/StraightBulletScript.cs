using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBulletScript : MonoBehaviour
{
   
    //���x
    public float speed = 5.0f;
    //����
    public float deathTime = 5.0f;
    //�v���C���[�_���ꍇ
    public bool toPlayer;

    //�ڕW�n�_
    Vector3 bulletVector;
    //���ˎ���
    float fireTime;

    // Start is called before the first frame update
    void Start()
    {
        if(toPlayer)
        {
            bulletVector = GameObject.Find("Player").transform.position - transform.position;
            Fire();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - fireTime > deathTime)
        {
            Destroy(gameObject);
        }
    }

    void Fire()
    {
        
        bulletVector.Normalize();

        GetComponent<Rigidbody>().AddForce(bulletVector * speed);

        fireTime = Time.time;
    }

    //�e�̕�������
    public void SetBulletVector(Vector3 vec)
    {
        bulletVector = vec;

        Fire();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //����������
        if(collision.gameObject.CompareTag("Player"))
        {
            //Player�̗̑͂̃X�N���v�g
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);

            Destroy(gameObject);
        }
        else if(!collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
