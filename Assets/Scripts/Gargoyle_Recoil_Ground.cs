﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Recoil_Ground : StateMachineBehaviour
{
    // TODO: break flying recoil and charge scripts, separating rotation, to be reused in ground fireball
    public static float recoilTime = 1f;
    private float _remainingRecoilTime = recoilTime;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _remainingRecoilTime -= Time.deltaTime;
        animator.SetFloat("Recoil_Time", _remainingRecoilTime);
    }

    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        animator.ResetTrigger("Throw_Fireball");
        animator.SetFloat("Recoil_time", recoilTime);
    }
}
