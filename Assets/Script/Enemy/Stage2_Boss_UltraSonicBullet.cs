using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Boss_UltraSonicBullet : MonoBehaviour
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
        this.transform.localScale = new Vector3(this.transform.localScale.x, gameObject.transform.localScale.y +(Time.time - startTime), this.transform.localScale.z);
        if (startTime + Timer < Time.time) //���˂���Timer���̎��Ԍo������
        {
            Destroy(gameObject); //���g���폜
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Player�̗̑͂̃X�N���v�g
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();

            ps.TakeDamage(1);

            //���g���폜
            Destroy(gameObject);

        }
    }
}
