using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour

{
    private Rigidbody[] rigidbodies;
    private Animator animator;
    NavMeshAgent navMeshAgent;
    AttackEnemyController enemyAttack;
    public Transform target;

    public Transform backWardPoint;

    public float attackDis;
    public float health = 100f;  
   void Start()
    {   
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemyAttack = GetComponentsInChildren<AttackEnemyController>()[0];
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        SetEnabled(false);
    }
    // Start is called before the first frame update   
    private void Update() {
        if(health > 0)
            FaceTarget(target.position);
    }
    void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = isKinematic;
        }

        animator.enabled = !enabled;
    }
    public void Attack()
    {
        enemyAttack.KnifeAttack();
    }
    public void BottleAttack()
    {
        enemyAttack.BottleAttack();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health < 0)
            SetEnabled(true);

    }
    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        animator.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1f);  
    }
}
