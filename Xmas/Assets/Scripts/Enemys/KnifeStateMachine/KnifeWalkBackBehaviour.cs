using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeWalkBackBehaviour : StateMachineBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    Transform target;

    Vector3 relativePoint;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = animator.GetComponent<EnemyController>().target;
        navMeshAgent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();

        navMeshAgent.updateRotation = false;
        Vector3 relativePoint = animator.transform.InverseTransformPoint(target.position);
        navMeshAgent.SetDestination(relativePoint*(-1.5f));
    }

    // // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     FaceTarget(target.position, animator);
    // }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {  
        navMeshAgent.updateRotation = true;
    }

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
