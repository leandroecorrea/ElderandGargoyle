using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Take_Off : StateMachineBehaviour
{
    private Rigidbody2D _rb;
    private float _target;
    public float takeOffSpeed = 1f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0f;
        _target = animator.GetComponent<Gargoyle>().initialHeight;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 movement = new Vector2(0, 1f);
        if (_rb.position.y < _target)
        {
            _rb.transform.Translate(movement * takeOffSpeed * Time.deltaTime);
            return;
        }
        animator.SetBool("IsPatrolling", true);
    }
}
