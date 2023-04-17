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
    public AudioSource audioSrc2;
   public bool isongrass = false;

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
            if (isongrass == false)
            {
                if (!audioSrc.isPlaying)
                {
                    audioSrc.Play();
                }
            }
            else
            {
                if (!audioSrc2.isPlaying)
                {
                    audioSrc2.Play();
                }
            }
            
        }
        else
        {
            audioSrc.Stop();
            audioSrc2.Stop();
        }



    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementspeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("is on grass");
        if (collision.gameObject.tag == "grass")
        {
            isongrass = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "grass")
        {
            isongrass = false;
        } 
    }
}
