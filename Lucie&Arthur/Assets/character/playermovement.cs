using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour 
{
    public float movementspeed = 5;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    bool ismoving = false;
    public AudioSource audioSrc;
    bool isongrass = false;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
        
        if (movement.sqrMagnitude >= 0.01f)
        {
            ismoving = true; 
        }
        else
        {
            ismoving = false;
        } 
        

        if(ismoving == true)
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();                
            }           
            
        }
        else
        {
            audioSrc.Stop();            
        }



    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementspeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "grass")
        {
            isongrass = true;
        }
    }
}
