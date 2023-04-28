using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBulletScript : MonoBehaviour
{
   
    //���x
    public float speed = 5.0f;
    //����
    public float deathTime = 5.0f;

    //�ڕW�n�_
    Vector3 goalPosition;
    //���ˎ���
    float fireTime;

    // Start is called before the first frame update
    void Start()
    {
        goalPosition = GameObject.Find("Player").transform.position;

        GetComponent<Rigidbody>().AddForce((goalPosition - transform.position) * speed);

        fireTime = Time.time;

        Debug.Log("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - fireTime > deathTime)
        {
            Destroy(gameObject);
        }
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
