using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileMoveScript : MonoBehaviour
{
    //��{�̈ʒu����̈ړ���
    public Vector3 MoveValue;
    //�ړ��X�s�[�h
    public float speed = 1.0f;
    //�����ʒu
    private Vector3 BasePos;
    //�|�ʒu
    private Vector3 m_Pos;
    //+�ʒu
    private Vector3 p_Pos;

    //�ړ������؂�ւ��t���O
    public bool bMove = true;

    // Start is called before the first frame update
    void Start()
    {
        BasePos = transform.position;
        m_Pos = BasePos - MoveValue;
        p_Pos = BasePos + MoveValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(bMove)
        {
            transform.position += (MoveValue * speed * Time.deltaTime);

            

            if((transform.position - p_Pos).sqrMagnitude <= 2 * speed * Time.deltaTime)
            {
                bMove = false;
            }
        }
        else
        {
            transform.position -= (MoveValue * speed * Time.deltaTime);

            if ((m_Pos - transform.position).sqrMagnitude <= 2 * speed * Time.deltaTime)
            {
                bMove = true;
            }
        }
        
    }
}
