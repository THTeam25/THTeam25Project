using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeColliderSoundScript : MonoBehaviour
{
    public bool issound;
    // Start is called before the first frame update
    void Start()
    {
        issound = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            issound = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            issound = false;
        }
    }
}

