using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Claw : StateMachineBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _movement;
    public float speed = 2f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
        _movement = new Vector2(0.03f, 0);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_movement.x < 1.5f)
        {
            _movement.x += Mathf.Pow(_movement.x, 2);
        }
        else
        {
            _movement.x = 0f;
        }
        _rb.transform.Translate(_movement * speed * Time.deltaTime);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Claw");
        animator.SetTrigger("Leap_Off");
    }
}
