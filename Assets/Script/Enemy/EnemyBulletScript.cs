using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    float startTime; //���ˎ���
    public float Timer = 0.5f; //�o�ߎ���
    //�G�l�~�[�̃��W�b�g�{�f�B
    private Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; //���˂��ꂽ�������o���Ă���
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime + Timer < Time.time) //���˂���0.5�b�o������
        {
            Destroy(gameObject); //���g���폜
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Player�̗̑͂̃X�N���v�g
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);

            //���g���폜
            Destroy(gameObject);
        }
    }
}
