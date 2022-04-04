using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Dive_Landing : StateMachineBehaviour
{
    private Rigidbody2D _rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb.gravityScale = 0f;
    }
}
