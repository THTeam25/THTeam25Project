using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileScript : MonoBehaviour
{
    //PlayerScript
    private PlayerScript pS;
    //ぶつかった杭

    // Start is called before the first frame update
    void Start()
    {
        pS = GameObject.Find("Player").GetComponent<PlayerScript>();    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pS = GameObject.Find("Player").GetComponent<PlayerScript>();
        //Playerの柱フラグがオンになっていたら位置固定
        //
        if (pS.isSeize && pS.hitPile)
        {
            GameObject.Find("Player").transform.position = GameObject.Find("Player").GetComponent<PlayerScript>().hitPile.transform.position;

            //柱につかまっているときは速度をゼロにする
            GameObject.Find("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //ぶつかったPlayerの柱フラグをオンにする
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerScript>().isPile = true;
            GameObject.Find("Player").GetComponent<PlayerScript>().hitPile = gameObject;
            
            
            //地面フラグオン
            //other.gameObject.GetComponent<PlayerScript>().isGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //ぶつかったPlayerの柱フラグをオンにする
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerScript>().hitPile = null;
            //地面フラグオン
            //other.gameObject.GetComponent<PlayerScript>().isGround = true;
        }
    }


}
