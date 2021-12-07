using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KnifeIdleBehaviour : StateMachineBehaviour
{
    NavMeshAgent navMeshAgent;
    Transform target;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = animator.GetComponent<EnemyController>().target;
        navMeshAgent = animator.GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(animator.transform.position);
        navMeshAgent.updateRotation = true;
        //habria que ver como encontrar al target
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector3.Distance(animator.transform.position, target.position) <= 2f)
            animator.SetTrigger("Attack");
            
        if(Vector3.Distance(animator.transform.position, target.position) > 2f)
        {
            navMeshAgent.SetDestination(target.position);
            animator.SetBool("Walking",true);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
