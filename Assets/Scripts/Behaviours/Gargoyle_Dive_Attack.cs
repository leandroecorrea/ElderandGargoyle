using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Dive_Attack : StateMachineBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _movement;
    public float flyingDiveSpeed = 2f;
    public float _landingDistance = 3f;
    Vector2 _target;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
        Collider2D attackBox = GameObject.FindGameObjectWithTag("Attack Box").transform.GetComponent<Collider2D>();
        _target = new Vector2(attackBox.bounds.extents.x / 2, attackBox.bounds.min.y);
        _rb.gravityScale = 2f;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetDistance(animator);
        MoveTo(_target);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsPatrolling", false);
    }

    private void MoveTo(Vector2 target)
    {
        _movement = target.normalized;
        _rb.transform.Translate(_movement * flyingDiveSpeed * Time.fixedDeltaTime);
    }   

    private void SetDistance(Animator animator)
    {
        float gargoyleBoundsPositionY = animator.transform.GetComponent<Collider2D>().bounds.min.y;
        float distance = Mathf.Abs(gargoyleBoundsPositionY - _target.y);
        animator.SetFloat("Landing_Distance", distance);
    }
}
