using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArrowScript : MonoBehaviour
{
    //PlayerGameObject
    private GameObject player;
    //PlayerScript
    private PlayerScript pS;
    //�摜
    private Image image;

    public Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        //�ϐ��ݒ�
        player = GameObject.Find("Player");
        pS = player.GetComponent<PlayerScript>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //�W�����v���ߒ��͉摜��\��
        if(pS.jumpChargeFlag)
        {
            image.enabled = true;

            //��]�v�Z
            //temp;
            temp = new Vector3(0, 0, 0);
            float xinput = pS.playerInput.actions["JumpCharge"].ReadValue<Vector2>().x;
            float yinput = pS.playerInput.actions["JumpCharge"].ReadValue<Vector2>().y;

            temp.z = Mathf.Atan2(-xinput, yinput) * Mathf.Rad2Deg;

            //���摜��]
            image.transform.rotation = Quaternion.Euler(temp);
        }
        else
        {
            image.enabled = false;
        }
    }
}
