using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltconveyorScript : MonoBehaviour
{
    //ベルトコンベアで流れる方向
    public enum MoveVec
    {
        right,
        left,
    };

    //PlayerObject
    private GameObject player;

    //流すスピード
    public float speed = 1.0f;

    //流す方向
    public MoveVec moveVec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //PlayerObjectがtrueだったらながす
        if(player)
        {
            if(moveVec == MoveVec.left)
            {
                player.transform.Translate(new Vector3(0,0,-1) * speed * Time.deltaTime,Space.World);
            }
            else
            {
                player.transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime, Space.World);
            }
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }
}
