using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttack : MonoBehaviour
{
    public GameObject bloodEffect;
    public float attackAngle;
    Animator animator;

    [SerializeField] private float maxDistance;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform player;
    private void Start() {
        animator = GetComponentInParent<Animator>();
    }
    public void Attack() 
    {
        Vector3 scndAttack = new Vector3(Mathf.Cos(attackAngle)*player.forward.x-Mathf.Sin(attackAngle)*player.forward.z,0f,Mathf.Sin(attackAngle)*player.forward.x+Mathf.Cos(attackAngle)*player.forward.z);
        Vector3 thrdAttack = new Vector3(Mathf.Cos(-attackAngle)*player.forward.x-Mathf.Sin(-attackAngle)*player.forward.z,0f,Mathf.Sin(-attackAngle)*player.forward.x+Mathf.Cos(-attackAngle)*player.forward.z);
        RaycastHit hit;
        // Debug.Log(Physics.Raycast(pointA.position, player.forward,out hit, maxDistance) + " : " + (Physics.Raycast(pointA.position, scndAttack,out hit, maxDistance) + " : " + (Physics.Raycast(pointA.position, thrdAttack,out hit, maxDistance))));
        if(Physics.Raycast(pointA.position, player.forward,out hit, maxDistance))
        {
            ExtremityController extremityController = hit.transform.GetComponent<ExtremityController>();
            if (extremityController != null)
            {
                GameObject blood = Instantiate(bloodEffect,hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(blood,0.2f);
                extremityController.ExtremityTakeDamage(10f);   
            }
        }
        else if(Physics.Raycast(pointA.position, scndAttack,out hit, maxDistance))
        {
            ExtremityController extremityController = hit.transform.GetComponent<ExtremityController>();
            if (extremityController != null)
            {
                GameObject blood = Instantiate(bloodEffect,hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(blood,0.2f);
                extremityController.ExtremityTakeDamage(10f);   
            }
        } 
        else if(Physics.Raycast(pointA.position, thrdAttack,out hit, maxDistance))
        {
            ExtremityController extremityController = hit.transform.GetComponent<ExtremityController>();
            if (extremityController != null)
            {
                GameObject blood = Instantiate(bloodEffect,hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(blood,0.2f);
                extremityController.ExtremityTakeDamage(10f);   
            }
        } 
        
        
    }

    public void BatAttack()
    {
        RaycastHit hit;
        Debug.Log(Physics.Raycast(pointB.position, pointB.up,out hit, 2.3f));
        if(Physics.Raycast(pointB.position, pointB.up,out hit, 2.3f) )
        {
            // Debug.Log(hit.transform.name);
            ExtremityController extremityController = hit.transform.GetComponent<ExtremityController>();
            if (extremityController != null)
            {
                GameObject blood = Instantiate(bloodEffect,hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(blood,0.2f);
                extremityController.ExtremityTakeDamage(30f);
            }

        } 
    }
    private void OnDrawGizmos() 
    {   
        Vector3 scndAttack = new Vector3(Mathf.Cos(attackAngle)*player.forward.x-Mathf.Sin(attackAngle)*player.forward.z,0f,Mathf.Sin(attackAngle)*player.forward.x+Mathf.Cos(attackAngle)*player.forward.z);
        Vector3 thrdAttack = new Vector3(Mathf.Cos(-attackAngle)*player.forward.x-Mathf.Sin(-attackAngle)*player.forward.z,0f,Mathf.Sin(-attackAngle)*player.forward.x+Mathf.Cos(-attackAngle)*player.forward.z);
        
        Gizmos.DrawRay(pointA.position, player.forward*maxDistance);
        Gizmos.DrawRay(pointA.position, scndAttack.normalized*maxDistance);
        Gizmos.DrawRay(pointA.position, thrdAttack.normalized*maxDistance);
        Gizmos.DrawRay(pointB.position, pointB.up*2.3f);


    }
}
