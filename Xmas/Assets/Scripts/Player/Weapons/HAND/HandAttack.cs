using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttack : MonoBehaviour
{
    public GameObject bloodEffect;

    Animator animator;

    [SerializeField] private float maxDistance;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform player;
    private void Start() {
        animator = GetComponentInParent<Animator>();
    }
    public void Attack() 
    {
        
        RaycastHit hit;
        if(Physics.Raycast(pointA.position, player.forward,out hit, maxDistance))
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
        Gizmos.DrawRay(pointA.position, player.forward*maxDistance);
    }
}
