using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Fly_Fireball_Recoil : StateMachineBehaviour
{
    Vector2 _target;
    private Rigidbody2D _rb;
    private float _rotationSpeed = 75;
    public float desiredRotation = 0f;
    public static float recoilTime = 5f;
    private float _remainingRecoilTime = recoilTime;
    bool _backwardsRotation;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
        Collider2D attackBox = GameObject.FindGameObjectWithTag("Attack Box").transform.GetComponent<Collider2D>();
        _target = new Vector2(attackBox.bounds.extents.x / 2, attackBox.bounds.min.y);
        _target.Normalize();
        _backwardsRotation = animator.GetComponent<Gargoyle>().HasRotated;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        RotateBack(_backwardsRotation);
        _remainingRecoilTime -= Time.deltaTime;
        animator.SetFloat("Recoil_Time", _remainingRecoilTime);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // FIXME: shouldn't need to reset the number so it doesn't fits in a choice
        int outOfRangeChoice = 101;
        animator.SetInteger("Fly_Random_Choice", outOfRangeChoice);
        animator.SetBool("IsPatrolling", true);
        _remainingRecoilTime = recoilTime;
        animator.SetFloat("Recoil_Time", recoilTime);
        animator.ResetTrigger("Throw_Fireball");
    }


    private void RotateBack(bool backwardsRotation)
    {
        // check if y axis is rotated so there'll be no need of   boolean in gargoyle
        Quaternion toRotation;
        if (_rb.transform.rotation.z < desiredRotation)
        {
            if (backwardsRotation)
            {
                // FIXME: rotation is acting strange, need to research
                return;
            }
            toRotation = Quaternion.Euler(0, 0, 45);
            _rb.transform.rotation = Quaternion.RotateTowards(_rb.transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
