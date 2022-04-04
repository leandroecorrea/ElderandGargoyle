using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Throw_Fireball : StateMachineBehaviour
{
    MagicAttack _attack;
    public static float recoilTime = 5f;
    private float _remainingRecoilTime = recoilTime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _attack = animator.GetComponent<MagicAttack>(); 
        _attack.ThrowFireball();        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _remainingRecoilTime -= Time.deltaTime;
        animator.SetFloat("Recoil_Time", _remainingRecoilTime);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _remainingRecoilTime = recoilTime;
        animator.SetFloat("Recoil_Time", recoilTime);
    }
}
