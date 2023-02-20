using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileMoveScript : MonoBehaviour
{
    //Šî–{‚ÌˆÊ’u‚©‚ç‚ÌˆÚ“®—Ê
    public Vector3 MoveValue;
    private Vector3 BasePos;
    // Start is called before the first frame update
    void Start()
    {
        BasePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = BasePos + (Mathf.Sin(Time.time) * MoveValue);
    }
}
