using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GomGunScript : MonoBehaviour
{
    //îÚÇŒÇ∑óÕ
    public float power = 1.0f;
    //offset
    public Vector3 offset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //PlayerÇ™ìñÇΩÇ¡ÇΩÇÁ
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;

            //SpawnPointÇ…PlayerÇçáÇÌÇπÇÈ
            player.transform.position = transform.GetChild(0).gameObject.transform.position;

            //PlayerîÚÇŒÇ∑
            player.GetComponent<Rigidbody>().AddForce(Vector3.forward * power);
        }
    }
}
