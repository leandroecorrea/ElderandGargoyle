using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Gargoyle : MonoBehaviour
{    
    private Rigidbody2D rb;
    private Animator animator;       
    private bool _shouldFlip;       
    public MagicAttack magicAttack;
    public Shake shake;
    public float initialHeight;
    public bool HasRotated { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                   
        animator = gameObject.GetComponent<Animator>();
        magicAttack = GetComponent<MagicAttack>();
        magicAttack.Animator = animator;
        magicAttack.Movement = this;
        initialHeight = rb.position.y;
        HasRotated = false;
    }         

    public void FaceForward()
    {
        if(_shouldFlip)
        {
           StartCoroutine(Flip());
        }
    }
    private IEnumerator Flip()
    {
        // TODO: Check direction of attack box so i can remove trigger comprobation
        _shouldFlip = false;
        // TODO: this boolean is just for the rotation in the fireball, replace it with comprobation on the transform
        HasRotated = !HasRotated;
        yield return new WaitForSeconds(0.2f);        
        rb.transform.Rotate(0, 180, 0);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attack Box")
        {
            _shouldFlip = true;                   
            animator.SetBool("HasChosenMovement", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Landing_Area")
        {            
            // TODO: should check this in landing animation script?
            animator.SetBool("InLandingZone", true);
            return;
        }
        if(other.gameObject.tag == "Attack Box")
        {            
            // This may be in a separate class (also a script in animator fsm?)
            if(!animator.GetBool("HasChosenMovement"))
            {
                Debug.Log("making a choice when has chosen movement is: " + animator.GetBool("HasChosenMovement"));
                SetFlyingRandomChoice();
                animator.SetBool("HasChosenMovement", true);
            }
        }
    }

    private void SetFlyingRandomChoice()
    {
        //int randomNumber = UnityEngine.Random.Range(0, 100);
        int randomNumber = 50;
        animator.SetInteger("Fly_Random_Choice", randomNumber);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "floor")
        {
            // play landing sound
            StartCoroutine(shake.ShakeCamera(0.1f, 0.1f));
        }
    }
}