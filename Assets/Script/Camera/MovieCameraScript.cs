using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieCameraScript : MonoBehaviour
{
    //�S�[���n�_
    public Vector3 GoalPosition;
    //�J�����ړ����x
    public float moveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GoalPosition, moveSpeed * Time.deltaTime);
        
        //�S�[���ɂ������A�N�e�B�u
        if(Vector3.SqrMagnitude(GoalPosition - transform.position) <= 1.0f)
        {
            //gameObject.SetActive(false);
            gameObject.GetComponent<Camera>().enabled = false;//�S�[���ɂ������A�N�e�B�u�ɂ���
        }
    }
}
