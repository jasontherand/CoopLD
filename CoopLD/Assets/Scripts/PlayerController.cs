using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //player movement 
    public float speed;

    //Is the player in front of a ladder
    private bool climbable;


    //player's rgidbody
    private Rigidbody rb;
    //player's animator
    private Animator anim;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = rb.velocity;

        movement.x = moveHorizontal * speed;

        if (climbable) {
            float moveVertical = Input.GetAxis("Vertical");
            movement.y = moveVertical * speed;
        }

        rb.velocity = movement;

    }
    private void OnTriggerEnter(Collider theCollider)
    {
        Debug.Log("Triggering");
       if(theCollider.tag == "Ladder")
        {
            Debug.Log("Ladder");
            MakeClimbable();
        }
    }
    private void OnTriggerExit(Collider theCollider)
    {
        if (theCollider.tag == "Ladder")
        {
            Debug.Log("Ladder");
            RemoveClimbable();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliding");
    }


    void MakeClimbable()
    {
        //turn off gravity
        rb.useGravity = false;
        //allow vertical movement
        climbable = true;
        //tell the animator
        anim.SetBool("Climbable", true);
    }
    void RemoveClimbable()
    {
        rb.useGravity = true;
        climbable = false;
        anim.SetBool("Climbable", false);
    }




    bool IsClimbable()
    {
        return climbable;
    }
}
