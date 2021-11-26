using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public GameObject bloodEffect;
    public Transform pointA;
    Animator animator;

    [SerializeField] private float maxDistance;
    private void Start() {
        animator = GetComponentInParent<Animator>();
    }
    private void Update() 
    {
        RaycastHit hit;
        if(Physics.Raycast(pointA.position, transform.up,out hit, maxDistance) && animator.GetBool("Attacking"))
        {
            Debug.Log(hit.transform.name);
            ExtremityController extremityController = hit.transform.GetComponent<ExtremityController>();
            if (extremityController != null)
            {
                GameObject blood = Instantiate(bloodEffect,hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(blood,0.2f);
                Debug.Log("1");
                extremityController.ExtremityTakeDamage(30f);   
            }

        }    
    }
    private void OnDrawGizmos() 
    {
        Gizmos.DrawRay(pointA.position, transform.up*maxDistance);
    }

    // private void OnTriggerEnter(Collider other) 
    // {
    //     Debug.Log(other.transform.name);
    //     ExtremityController extremityController = other.transform.GetComponent<ExtremityController>();

    //     if (extremityController != null&& timer > 0.35f)//tirar tres rayos, ver en cual pega mejor y hacer aparecer el efecto ahi
    //     {
    //         GameObject blood = Instantiate(bloodEffect,pointA.position,Quaternion.identity);
    //         Destroy(blood,0.2f);
    //         extremityController.ExtremityTakeDamage(30f);  
    //         timer = 0f;  
    //     }
    // }

}
