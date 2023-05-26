using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_HintScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = false; // gameObjectのCanvasコンポーネントを非表示
    }

    // Update is called once per frame
    void Update()
    {
        GameObject cameraChangePoint_Boss = GameObject.Find("CameraChangePoint_Boss");
        CameraSwitcher CCP = cameraChangePoint_Boss.GetComponent<CameraSwitcher>();
        if(CCP.bossmoveflag == true)
        {
            gameObject.GetComponent<Canvas>().enabled = true; // gameObjectのCanvasコンポーネントを表示
         }
    }
}
