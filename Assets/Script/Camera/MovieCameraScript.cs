using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieCameraScript : MonoBehaviour
{
    //ゴール地点
    public Vector3 GoalPosition;
    //カメラ移動速度
    public float moveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GoalPosition, moveSpeed * Time.deltaTime);
        
        //ゴールについたら非アクティブ
        if(Vector3.SqrMagnitude(GoalPosition - transform.position) <= 1.0f)
        {
            gameObject.SetActive(false);
        }
        ////スキップ機能
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    gameObject.SetActive(false);
        //}
    }
    public void Skip()
    {
        gameObject.SetActive(false);
    }
}
