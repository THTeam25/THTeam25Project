using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_BossAttack01 : MonoBehaviour
{
    public GameObject[] piles;

    public Vector3[] triangle;
    public Vector3[] untriangle;
    public Vector3[] horizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePilePos()
    {
        int num = Random.Range(0, 3);
        Vector3[] targetVector = new Vector3[3]; 
        switch (num)
        {
            case 0:
                targetVector = triangle;
                break;
            case 1:
                targetVector = untriangle;
                break;
            case 2:
                targetVector = horizontal;
                break;
        }

        for(int i = 0;i < 3;i++)
        {
            piles[i].transform.position = targetVector[i];
        }

    }
}
