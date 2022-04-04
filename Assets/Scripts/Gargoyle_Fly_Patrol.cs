using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Fly_Patrol : StateMachineBehaviour
{    
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Gargoyle _gargoyle;
    public float speed = 2f;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {        
        _rb = animator.GetComponent<Rigidbody2D>();
        _movement = new Vector2(0.5f, 0f);
        _gargoyle = animator.GetComponent<Gargoyle>();
        animator.SetBool("IsPatrolling", false);
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _gargoyle.FaceForward();
        _rb.transform.Translate(_movement * speed * Time.deltaTime);
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // FIXME: shouldn't need to reset the number so it doesn't fits in a choice
        int outOfRangeChoice = 101;        
        animator.SetInteger("Fly_Random_Choice", outOfRangeChoice);
        animator.SetBool("IsPatrolling", false);
    }
}
