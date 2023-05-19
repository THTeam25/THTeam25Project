using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLifeUIScript : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[10];
    private int lifePoint = 10;
    private bool Flag;

    void Start()
    {
    }

    void Update()
    {
        GameObject NH;
        PlayerLifeScript PLS;

        NH = GameObject.Find("Player");
        PLS = NH.GetComponent<PlayerLifeScript>();


        if (lifePoint > PLS.life)
        {
            Flag = true;
        }

        if(Flag)
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
            Flag = false;
        }
    }

}

