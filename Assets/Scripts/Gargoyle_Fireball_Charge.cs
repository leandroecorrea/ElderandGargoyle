using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Fireball_Charge : StateMachineBehaviour
{
    private Rigidbody2D _rb;
    private float _rotationSpeed = 75;
    public static float chargeTime = 3f;
    private float _remainingchargeTime = chargeTime;
    public float desiredRotation = -0.40f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
        Collider2D attackBox = GameObject.FindGameObjectWithTag("Attack Box").transform.GetComponent<Collider2D>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bool backwardsRotation = animator.GetComponent<Gargoyle>().HasRotated;
        Rotate(backwardsRotation);
        _remainingchargeTime -= Time.deltaTime;
        animator.SetFloat("Charge_Time", _remainingchargeTime);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _remainingchargeTime = chargeTime;
        animator.SetBool("IsPatrolling", true);
        animator.SetFloat("Charge_Time", chargeTime);
        Debug.Log("transform rotation on exit" + _rb.transform.rotation);
    }

    private void Rotate(bool backwardsRotation)
    {
        if (_rb.transform.rotation.z > desiredRotation)
        {
            Quaternion toRotation;
            if (backwardsRotation)
            {
                // FIXME: rotation is acting strange, need to research
                return;
            }
            toRotation = Quaternion.Euler(0, 0, -45);
            _rb.transform.rotation = Quaternion.RotateTowards(_rb.transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
