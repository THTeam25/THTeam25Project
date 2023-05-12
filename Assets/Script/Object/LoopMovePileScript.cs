using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMovePileScript : MonoBehaviour
{
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    [SerializeField] private Transform pos3;
    [SerializeField] private Transform pos4;
    [SerializeField] private Transform pos5;
    [SerializeField] private Transform pos6;

    [SerializeField] private float moveTime = 1.0f;      // 移動にかかる時間（秒）
    [SerializeField] private float speed = 1.0f;         // 移動速度

    private Vector3 startPosition;     // 移動開始時の位置
    private float startTime;           // 移動開始時間

    private int loopnum;

    private bool goflag;//行きかどうか

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;
        loopnum = 2;
        goflag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(goflag == true)
            switch (loopnum)
            {

                case 2:
                    Move(pos2);
                    if (transform.position == pos2.position)
                    {
                        loopnum += 1;
                    }
                    break;
                case 3:
                    Move(pos3);
                    if (transform.position == pos3.position)
                    {
                        loopnum += 1;
                    }
                    break;
                case 4:
                    Move(pos4);
                    if (transform.position == pos4.position)
                    {
                        loopnum += 1;
                    }
                    break;
                case 5:
                    Move(pos5);
                    if (transform.position == pos5.position)
                    {
                        loopnum += 1;
                    }
                    break;
                case 6:
                    Move(pos6);
                    if (transform.position == pos6.position)
                    {
                        loopnum -= 1;
                        goflag = false;
                    }
                    break;
                default:
                    Debug.Log("行きエラー");
                    break;
            }

        else if (goflag == false)
            switch (loopnum)
            {
                case 1:
                    Move(pos1);
                    if (transform.position == pos1.position)
                    {
                        loopnum += 1;
                        goflag = true;
                    }
                    break;
                case 2:
                    Move(pos2);
                    if (transform.position == pos2.position)
                    {
                        loopnum -= 1;
                    }
                    break;
                case 3:
                    Move(pos3);
                    if (transform.position == pos3.position)
                    {
                        loopnum -= 1;
                    }
                    break;
                case 4:
                    Move(pos4);
                    if (transform.position == pos4.position)
                    {
                        loopnum -= 1;
                    }
                    break;
                case 5:
                    Move(pos5);
                    if (transform.position == pos5.position)
                    {
                        loopnum -= 1;
                    }
                    break;
                default:
                    Debug.Log("帰りエラー");
                    break;

            }
    }

    private void Move(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
