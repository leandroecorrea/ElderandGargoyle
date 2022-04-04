using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Throw_Fireball : StateMachineBehaviour
{
    MagicAttack _attack;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _attack = animator.GetComponent<MagicAttack>(); 
        _attack.ThrowFireball();        
    }   
}
