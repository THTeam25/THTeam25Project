using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_Attack3 : MonoBehaviour
{
    //�~�T�C���I�u�W�F�N�g
    public GameObject missile;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Spawnmissile",3.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //missile����
    public void Spawnmissile()
    {
        Instantiate(missile, transform.position, Quaternion.identity);
    }
}