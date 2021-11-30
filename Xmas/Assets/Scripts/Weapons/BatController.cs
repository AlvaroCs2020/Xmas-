using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public GameObject bloodEffect;
    public Transform pointA;
    Animator animator;

    [SerializeField] private float maxDistance;

    float timer = 0;
    private void Start() {
        animator = GetComponentInParent<Animator>();
    }
    private void Update() 
    {
        timer +=Time.deltaTime;
        RaycastHit hit;
        if(Physics.Raycast(pointA.position, transform.up,out hit, maxDistance) && animator.GetBool("Attacking"))
        {
            Debug.Log(hit.transform.name);
            ExtremityController extremityController = hit.transform.GetComponent<ExtremityController>();
            if (extremityController != null && timer > 0.6f)
            {
                GameObject blood = Instantiate(bloodEffect,hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(blood,0.2f);
                extremityController.ExtremityTakeDamage(30f);
                timer = 0f;   
            }

        }    
    }
    private void OnDrawGizmos() 
    {
        Gizmos.DrawRay(pointA.position, transform.up*maxDistance);
    }
}
