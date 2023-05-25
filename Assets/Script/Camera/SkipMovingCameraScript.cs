using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipMovingCameraScript : MonoBehaviour
{
    public Camera moviecamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Skip()
    {
        moviecamera.enabled = false;
    }
}
