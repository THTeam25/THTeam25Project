using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileScript : MonoBehaviour
{
    //PlayerScript
    private PlayerScript pS;
    //
    private float playerPositionOffset = 0.3f; 

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
            //���ɓ��͂ɉ�����Player�ʒu�Œ�
            float x = pS.playerInput.actions["JumpCharge"].ReadValue<Vector2>().x;
            float y = pS.playerInput.actions["JumpCharge"].ReadValue<Vector2>().y;

            Vector3 rotateVector = new Vector3(0,y,x);
            GameObject.Find("Player").transform.position = GameObject.Find("Player").GetComponent<PlayerScript>().hitPile.transform.position +
                rotateVector * playerPositionOffset * pS.GetExtendValue();


            //���ɂ��܂��Ă���Ƃ��͑��x���[���ɂ���
            GameObject.Find("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //�Ԃ�����Player�̒��t���O���I���ɂ���
        if(other.gameObject.CompareTag("Player"))
        {
            //�q�b�g����������
            other.gameObject.GetComponent<PlayerScript>().isPile = true;
            GameObject.Find("Player").GetComponent<PlayerScript>().hitPile = gameObject;

            //Auto�������玩���ŕ߂܂�
            if(other.gameObject.GetComponent<PlayerScript>().pT == PlayerScript.pileType.Auto)
            {
                other.gameObject.GetComponent<PlayerScript>().isSeize = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //�Ԃ�����Player�̒��t���O���I���ɂ���
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerScript>().hitPile = null;

        }
    }


}
