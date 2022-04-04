using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float speed = 10f;
    public Rigidbody2D rb;    

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;     
    }    
    void Update()
    {
        rb.transform.Translate(Vector2.right * speed * Time.deltaTime);        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (NotFriendlyTrigger(other.gameObject.name))
        {
            Destroy(gameObject);
        }
    }
    private static bool NotFriendlyTrigger(string triggerName)
    {
        return triggerName != "Gargoyle" && triggerName != "AttackBox" && triggerName != "LandingArea";
    }
}
