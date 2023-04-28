using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntaractChacker : MonoBehaviour
{
    private CameraSwitcher cS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCameraSwitcher(CameraSwitcher cs)
    {
        cS = cs;
    }

    public void Intaract()
    {
        if(cS != null)
        {
            cS.Intaract();
        }
    }
}
