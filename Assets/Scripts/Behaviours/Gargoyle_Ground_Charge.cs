using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Ground_Charge : StateMachineBehaviour
{
    public static float chargeTime = 2f;
    private float _remainingChargeTime = chargeTime;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _remainingChargeTime -= Time.deltaTime;
        animator.SetFloat("Charge_Time", _remainingChargeTime);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _remainingChargeTime = chargeTime;
        animator.SetFloat("Charge_Time", chargeTime);
    }
}
