using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour

{
    private Rigidbody[] rigidbodies;
    private Animator animator;
    NavMeshAgent navMeshAgent;
    public Transform target;

    public Transform backWardPoint;

    public float attackDis;
    public float health = 100f;  
   void Start()
    {   
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        SetEnabled(false);
    }
    // Start is called before the first frame update   
    void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = isKinematic;
        }

        animator.enabled = !enabled;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health < 0)
            SetEnabled(true);

    }
}
