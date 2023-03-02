using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownScript : MonoBehaviour
{
    private float StartPos;

    void Start()
    {
        StartPos = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, StartPos + Mathf.PingPong(Time.time * 2f, 5), transform.position.z);
    }
}
