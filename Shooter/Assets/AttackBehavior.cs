using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : StateMachineBehaviour
{

    Transform player;

    float attackRange = 6;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player.transform);

        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance > attackRange)
        {
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsRun", true);
        }
        else
        {
            animator.SetBool("IsAttack", true);
            animator.SetBool("IsRun", false);
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
