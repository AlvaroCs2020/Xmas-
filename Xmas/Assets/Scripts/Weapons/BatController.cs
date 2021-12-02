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
    private void OnDrawGizmos() 
    {
        // Gizmos.DrawRay(pointA.position, pointA.up*maxDistance);
    }
}
