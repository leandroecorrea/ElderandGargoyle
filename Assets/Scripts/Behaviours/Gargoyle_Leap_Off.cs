using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Leap_Off : StateMachineBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _movement;
    public float speed = 35f;
    public float _patrollingDistance = 1f;
    Vector2 _target;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        Collider2D attackBox = GameObject.FindGameObjectWithTag("Attack Box").transform.GetComponent<Collider2D>();
        _target = new Vector2(attackBox.bounds.extents.x / 2, attackBox.bounds.extents.y / 2);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (ShouldPatrol(animator))
        {
            animator.SetBool("IsPatrolling", true);
            return;
        }
        MoveTo(_target);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // FIXME: shouldn't need to reset the number so it doesn't fits in a choice
        int outOfRangeChoice = 101;
        animator.ResetTrigger("Leap_Off");
        animator.SetInteger("Fly_Random_Choice", outOfRangeChoice);
    }
    private void MoveTo(Vector2 target)
    {
        _movement = target.normalized;
        _rb.transform.Translate(_movement * speed * Time.fixedDeltaTime);
    }
    private bool ShouldPatrol(Animator animator)
    {
        var gargoyleBoundsY = animator.transform.GetComponent<Collider2D>().bounds.min.y;
        var distance = Mathf.Abs(gargoyleBoundsY - _target.y);
        return distance < _patrollingDistance;
    }
}
