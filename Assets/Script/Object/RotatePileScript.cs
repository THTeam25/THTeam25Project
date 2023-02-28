using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePileScript : MonoBehaviour
{
    //��]�X�s�[�h
    public float speed = 100.0f;

    //��]��
    public Vector3 rotateVector = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateVector * speed * Time.deltaTime,Space.World);
    }
}
