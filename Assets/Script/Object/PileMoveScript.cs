using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileMoveScript : MonoBehaviour
{
    //基本の位置からの移動量
    public Vector3 MoveValue;
    //移動スピード
    public float speed = 1.0f;
    //初期位置
    private Vector3 BasePos;
    //－位置
    private Vector3 m_Pos;
    //+位置
    private Vector3 p_Pos;

    //移動方向切り替えフラグ
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
