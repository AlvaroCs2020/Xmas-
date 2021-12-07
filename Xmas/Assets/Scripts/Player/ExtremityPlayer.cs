using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtremityPlayer : MonoBehaviour
{
    PlayerMovement playerMovement;
    Animator animator;
    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        animator = GetComponentInParent<Animator>();
    }
    public void ExtremityTakeDamage(float damage)
    {
        // animator.SetTrigger("Hitted");
        playerMovement.TakeDamage(damage);
    }
}
