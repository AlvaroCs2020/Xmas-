using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAux : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
    public void EndAttack()
    {
        animator.SetBool("Attacking",false);
    }


    // Update is called once per frame

}
