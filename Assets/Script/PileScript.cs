using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileScript : MonoBehaviour
{
    //PlayerScript
    private PlayerScript pS;
    //�Ԃ������Y

    // Start is called before the first frame update
    void Start()
    {
        pS = GameObject.Find("Player").GetComponent<PlayerScript>();    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pS = GameObject.Find("Player").GetComponent<PlayerScript>();
        //Player�̒��t���O���I���ɂȂ��Ă�����ʒu�Œ�
        //
        if (pS.isSeize && pS.hitPile)
        {
            GameObject.Find("Player").transform.position = GameObject.Find("Player").GetComponent<PlayerScript>().hitPile.transform.position;

            //���ɂ��܂��Ă���Ƃ��͑��x���[���ɂ���
            GameObject.Find("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //�Ԃ�����Player�̒��t���O���I���ɂ���
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerScript>().isPile = true;
            GameObject.Find("Player").GetComponent<PlayerScript>().hitPile = gameObject;
            
            
            //�n�ʃt���O�I��
            //other.gameObject.GetComponent<PlayerScript>().isGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //�Ԃ�����Player�̒��t���O���I���ɂ���
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerScript>().hitPile = null;
            //�n�ʃt���O�I��
            //other.gameObject.GetComponent<PlayerScript>().isGround = true;
        }
    }


}
