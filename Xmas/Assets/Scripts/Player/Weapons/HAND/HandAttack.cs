using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttack : MonoBehaviour
{
    public GameObject bloodEffect;
    Animator animator;

    [SerializeField] private float maxDistance;
    private void Start() {
        animator = GetComponentInParent<Animator>();
    }
    private void Update() 
    {
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.up,out hit, maxDistance) && animator.GetBool("Attacking"))
        {
            Debug.Log(hit.transform.name);
            ExtremityController extremityController = hit.transform.GetComponent<ExtremityController>();
            if (extremityController != null)
            {
                GameObject blood = Instantiate(bloodEffect,hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(blood,0.2f);
                extremityController.ExtremityTakeDamage(10f);   
            }

        } 
        
    }
    private void OnDrawGizmos() 
    {
        Gizmos.DrawRay(transform.position, transform.up*maxDistance);
    }
}
