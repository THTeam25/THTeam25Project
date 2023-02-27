using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ǐՂ���G�p�̒ǐՔ���v���O����
public class ChackChais : MonoBehaviour
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
        if(other.gameObject.CompareTag("Player"))
        {
            //�ǐՃG�l�~�[�X�N���v�g�擾
            ChaisEnemyScript cs = transform.root.gameObject.GetComponent<ChaisEnemyScript>();

            //PlayerObject�ݒ�
            cs.SetPlayer(other.gameObject);

            //�ǐՊJ�n
            cs.SetChais(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //�ǐՃG�l�~�[�X�N���v�g�擾
            ChaisEnemyScript cs = transform.root.gameObject.GetComponent<ChaisEnemyScript>();

            //PlayerObject�ݒ�
            cs.SetPlayer(null);

            //�ǐՏI��
            cs.SetChais(false);
        }
    }
}
