using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle_Grounded_Behaviour : StateMachineBehaviour
{
    public static float delayToAct = 1f;
    private float remainingDelay = delayToAct;
    public Player player;
    public float gargoyleLOS = 2f;
    private Rigidbody2D _rb;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if((remainingDelay -= Time.deltaTime) < 0)
        {
            return;
        }
        SetGroundedRandomChoice(animator);
    }

    private void SetGroundedRandomChoice(Animator animator)
    {
        if(player != null)
        {
            Vector2 playerPosition = player.gameObject.GetComponent<Rigidbody2D>().position;
            Vector2 gargoylePosition = _rb.position;
            float distance = Vector2.Distance(playerPosition, gargoylePosition);
            if(Mathf.Abs(distance) < gargoyleLOS)
            {
                animator.SetTrigger("Claw");
                animator.SetInteger("Previous_Choice", (int)BehaviourChoices.Gargoyle_Claw);
            }
        }
        else
        {
            if(!RepeatedChoice(animator))
            {                
                int randomChoice = UnityEngine.Random.Range(0, 100);
                if(randomChoice < 80)
                {
                    animator.SetTrigger("Throw_Fireball");
                    animator.SetInteger("Previous_Choice", (int)BehaviourChoices.Gargoyle_Throw_Fireball);
                }
                animator.SetTrigger("Leap_Off");
                animator.SetInteger("Previous_Choice", (int)BehaviourChoices.Leap_Off);
            }
        }
    }

    private bool RepeatedChoice(Animator animator)
    {
        int previousChoice = animator.GetInteger("Previous_Choice");
        if (previousChoice == (int)BehaviourChoices.Leap_Off)
        {
            animator.SetTrigger("Throw_Fireball");
            animator.SetInteger("Previous_Choice", (int)BehaviourChoices.Gargoyle_Throw_Fireball);
            return true;
        }
        else if (previousChoice == (int)BehaviourChoices.Gargoyle_Throw_Fireball)
        {
            animator.SetTrigger("Leap_Off");
            animator.SetInteger("Previous_Choice", (int)BehaviourChoices.Leap_Off);
            return true;
        }
        return false;
    }
}

public enum BehaviourChoices
{
    Gargoyle_Claw = 1,
    Gargoyle_Throw_Fireball = 2,
    Leap_Off = 3,
    Gargoyle_Dive_Attack = 4,
    Gargoyle_Land = 5
}
