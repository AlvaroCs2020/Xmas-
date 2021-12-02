using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float turnTime = 0.1f;

    bool grounded;
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    //
    public Transform pointA;
    [SerializeField] private Transform player;
    public float attackAngle;
    //
    public LayerMask groundMask;
    float gravity = -9.8f;
    Vector3 velocity;
    public Transform cam;
    private Animator animator;
    
    float turnVel;
    // Update is called once per frame
    void Start() {
        animator = GetComponentsInChildren<Animator>()[0];
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;    
    }
    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        
        if (grounded && velocity.y<0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal,grounded? 0f: -1f,vertical).normalized;
        velocity.y += gravity;
        if(direction.magnitude > 0 && !( animator.GetBool("Attacking") && animator.GetBool("Bat") ))
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
        velocity.y += gravity;

        controller.Move(velocity * Time.deltaTime);

    }
}
