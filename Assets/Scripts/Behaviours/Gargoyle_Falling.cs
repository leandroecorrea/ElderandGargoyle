using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Falling : StateMachineBehaviour
{
    private Rigidbody2D _rb;
    public float landingSpeed = 0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
        _rb.gravityScale = 1;                
    }    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // landing feels ok just adding gravity
    }    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
