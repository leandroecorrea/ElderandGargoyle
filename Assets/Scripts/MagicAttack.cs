using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    public Transform magicPoint; 
    
    public GameObject firePrefab;
    private float _delay = 0.5f;

    public Animator Animator { private get; set; }
    public Gargoyle Movement { private get; set; }   

    public void ThrowFireball()
    {
        StartCoroutine(InstantiateFireball(_delay));         
    }

    private IEnumerator InstantiateFireball(float delay)
    {
        yield return new WaitForSeconds(delay);
        var instantiatedFire = Instantiate(firePrefab, magicPoint.position, magicPoint.rotation);
        instantiatedFire.transform.parent = gameObject.transform;
    }
}
