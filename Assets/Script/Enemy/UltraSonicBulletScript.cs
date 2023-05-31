using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraSonicBulletScript : MonoBehaviour
{
    float startTime; //���ˎ���
    public float Timer = 0.5f; //�o�ߎ���
    public float upsize = 0.5f;
    //�G�l�~�[�̃��W�b�g�{�f�B
    private Rigidbody enemyRb;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        startTime = Time.time; //���˂��ꂽ�������o���Ă���
        transform.LookAt(player.transform);//�v���C���[�̕���������������
    }

    // Update is called once per frame
    void Update()
    {
        

        this.transform.localScale += new Vector3(0, upsize, 0);

        if (startTime + Timer < Time.time) //���˂���Timer���̎��Ԍo������
        {
            Destroy(gameObject); //���g���폜
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�̗̑͂̃X�N���v�g
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);

            //���g���폜
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //���g���폜
            Destroy(gameObject);

        }
    }
}
