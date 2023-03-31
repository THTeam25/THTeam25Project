using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�ɒe��łG�p�̍��G����v���O����
public class CheckShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //�e�����X�N���v�g�擾
            EnemyShotScript ess = transform.root.gameObject.GetComponent<EnemyShotScript>();


            //���ˊJ�n
            ess.SetShot(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //�e�����X�N���v�g�擾
            EnemyShotScript ess = transform.root.gameObject.GetComponent<EnemyShotScript>();


            //�ǐՏI��
            ess.SetShot(false);
        }
    }
}
