using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    //�~�T�C���̈ړ����x
    public float speed = 5.0f;

    //�^�[�Q�b�g�I�u�W�F�N�g
    GameObject target;
    //���ˎ���
    float fireTime;

    public float deathTime = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");

        fireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Quaternion(��]�l)���擾
        Quaternion quaternion = Quaternion.LookRotation(target.transform.position - transform.position);
        // �Z�o������]�l�����̃Q�[���I�u�W�F�N�g��rotation�ɑ��
        transform.rotation = quaternion;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(Time.time - fireTime > deathTime)
        {
            Destroy(gameObject);
        }
    }
}
