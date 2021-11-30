using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtremityController : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyController enemyController;
    Animator animator;
    void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
        animator = GetComponentInParent<Animator>();
    }
    public void ExtremityTakeDamage(float damage)
    {
        animator.SetTrigger("Hitted");
        enemyController.TakeDamage(damage);
    }
}
