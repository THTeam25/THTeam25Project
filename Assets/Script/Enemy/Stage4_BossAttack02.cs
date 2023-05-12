using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_BossAttack02 : MonoBehaviour
{
    Vector3 goal;
    Vector3 initPos;
    GameObject player;

    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DigAttack()
    {
        goal = transform.position + Vector3.down * 10;

        InvokeRepeating("Move1",0,Time.deltaTime);
    }

    void Move1()
    {
        transform.Translate((goal - transform.position) * speed * Time.deltaTime);

        if(Vector3.Distance(goal,transform.position) <= 0.1f)
        {
            CancelInvoke("Move1");

            float temp = player.transform.position.z - transform.position.z;

            transform.position += new Vector3(0, 0, temp);

            goal = transform.position + Vector3.up * 30;

            InvokeRepeating("Move2",3,Time.deltaTime);
        }
    }

    void Move2()
    {
        transform.Translate((goal - transform.position) * speed * 2 * Time.deltaTime);

        if (Vector3.Distance(goal, transform.position) <= 0.1f)
        {
            CancelInvoke("Move2");

            float temp = initPos.z - transform.position.z;

            transform.position += new Vector3(0, 0, temp);

            goal = initPos;

            InvokeRepeating("Move3", 3, Time.deltaTime);
        }
    }

    void Move3()
    {
        transform.Translate((goal - transform.position) * speed * 2 * Time.deltaTime);

        if (Vector3.Distance(goal, transform.position) <= 0.1f)
        {
            CancelInvoke("Move3");
        }
    }
}
