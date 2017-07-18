using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //player movement 
    public float speed;

    //Is the player in front of a ladder
    private bool climbable;
    private Collider workableObject;

    //player's rgidbody
    private Rigidbody rb;
    //player's animator
    private Animator anim;

    // Use this for initialization
    void Start () {
        climbable = false;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

        //Handle Movement
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
        Debug.Log("collided with a " + theCollider.tag);
        //try to get a workable object
        WorkableObject workableObject = theCollider.GetComponentInParent<WorkableObject>();
        if (workableObject)
        {
            workableObject.playerActive = true;
        }
        //check if its a ladder
        switch (theCollider.tag) {
            case "Ladder": MakeClimbable();
                break;
        }
    }
    private void OnTriggerExit(Collider theCollider)
    {
        WorkableObject workableObject = theCollider.GetComponentInParent<WorkableObject>();
        if (workableObject)
        {
            workableObject.playerActive = false;
        }

        switch (theCollider.tag)
        {
            case "Ladder":
                RemoveClimbable();
                break;
        }
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
