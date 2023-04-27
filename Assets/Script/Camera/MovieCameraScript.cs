using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieCameraScript : MonoBehaviour
{
    //ÉSÅ[Éãínì_
    public Vector3 GoalPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GoalPosition, 20.0f * Time.deltaTime);
    }
}
