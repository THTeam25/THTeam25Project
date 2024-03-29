using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovePileScript : MonoBehaviour
{

    public float radius = 5f;
    public float speed = 2f;
    public float changeDirectionTime = 2f;

    private float currentAngle = 0f;
    private bool isMovingForward = true;
    public float timer = 0f;

    private Vector3 centerPos;
    private float starttimer = 0f;


    private void Start()
    {
        centerPos = transform.position + Vector3.up * radius;
        GetComponent<CapsuleCollider>().enabled = false;
    }

    private void Update()
    {
        if(starttimer < 0.5f)
        {
            starttimer += Time.deltaTime;
        }
        else if (starttimer >= 0.5f)
        {
            GetComponent<CapsuleCollider>().enabled = true;
        }

            timer += Time.deltaTime;


        if (timer >= changeDirectionTime)
        {
            isMovingForward = !isMovingForward;
            timer = 0f;
        }

        currentAngle += isMovingForward ? speed * Time.deltaTime : -speed * Time.deltaTime;

        float x = centerPos.x;
        float y = centerPos.y + -radius * Mathf.Sin(currentAngle * Mathf.Deg2Rad)/2;
        float z = centerPos.z + radius * Mathf.Cos(currentAngle * Mathf.Deg2Rad);

        transform.position = new Vector3(x, y, z);
    }
}


