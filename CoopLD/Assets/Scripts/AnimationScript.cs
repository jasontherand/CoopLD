using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    // Bool to determine direction for all animations
    bool facingRight = true;
    // Animator object

    Animator anim;
    Rigidbody rb;
    PlayerController pc;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        pc = GetComponent<PlayerController>();
    }



    //****Not used yet
    // Ints to specify what animation to use
    //int idle = 0;
    //int walk = 1;
    //int climb = 2; 

    // Update is called once per frame
    private void FixedUpdate()
    {

        //****Check horizontal movement to know if a flip should occur
        //get current horizontal movement
        float movementH = rb.velocity.x;
        //Apply the absolute speedH to the animator
        anim.SetFloat("SpeedH", Mathf.Abs(movementH));
        //flip if the direction of the animation and the movement are different

        if (movementH < 0 && facingRight)
        {
            Flip();
        }
        else
        if (movementH > 0 && !facingRight)
        {
            Flip();
        };

        if (Input.GetButton("DoAction"))
        {
            if (pc.HasWorkableObject())
            {
                if (pc.GetWorkableObject().workable)
                {
                    //tell the animator to work
                    Debug.Log("working1");
                    anim.SetBool("Working", true);
                }
            }
        }
        else
        {
            anim.SetBool("Working", false);
        }
    }


    void Flip()
    {
        //Flip the direction bool
        facingRight = !facingRight;
        //Get animation scale
        Vector3 aScale = transform.localScale;
        //flip over the x axis
        aScale.x *= -1;
        //apply
        transform.localScale = aScale;
    }
}
