using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float turnTime = 0.1f;

    public Transform cam;
    private Animator animator;
    
    float turnVel;
    // Update is called once per frame
    void Start() {
        animator = GetComponentsInChildren<Animator>()[0];
        Cursor.visible = false;    
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal,0f,vertical).normalized;

        if(direction.magnitude > 0)
        {   
            animator.SetBool("Walking",true);
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnVel, turnTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);

            Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
            controller.Move(moveDir.normalized*speed*Time.deltaTime);
        }else
        {
            animator.SetBool("Walking",false);
        }
    }
}
