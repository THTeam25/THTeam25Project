using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Boss_RotateAttack : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 5f;
    public float stoppingDistance = 2f;

    private Transform player;
    private bool isMoving = true;
    private Quaternion targetRotation;

    private int startnum;

    void Start()
    {
        targetRotation = transform.rotation;
        startnum = 0;
    }

    void Update()
    {
        GameObject manager_Stage2RandomMove = GameObject.Find("Manager_Stage2RandomMove");
        Boss_RamdomMove BRM = manager_Stage2RandomMove.GetComponent<Boss_RamdomMove>();
        if (BRM.behavior2Active == true)
        {
            if (startnum == 0)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
                Vector3 playerPos = player.position;
                playerPos.y = transform.position.y;
                transform.LookAt(playerPos);
                startnum = 1;
            }

            if (isMoving)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                direction.y = 0;
                transform.Translate(direction * speed * Time.deltaTime, Space.World);

                transform.Rotate(0f, Time.deltaTime * rotationSpeed, 0f);

                if (Vector3.Distance(transform.position, player.position) <= stoppingDistance)
                {
                    isMoving = false;
                    targetRotation = transform.rotation;
                }
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLifeScript ps = collision.gameObject.GetComponent<PlayerLifeScript>();
            ps.TakeDamage(1);
        }
    }
}
