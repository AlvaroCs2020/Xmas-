using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour

{
    private Rigidbody[] rigidbodies;
    private Animator animator;
    public float health = 100f;  
   void Start()
    {   
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
