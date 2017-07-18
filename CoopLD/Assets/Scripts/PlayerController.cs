using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //player movement 
    public float speedH;
    public float speedY;

    //Is the player in front of a ladder
    private bool climbable;
    private WorkableObject workableObject;

    //distance to ground when grounded
    private float distToGround;

    //player's rgidbody
    private Rigidbody rb;
    //player's animator
    private Animator anim;
    //player's Collider
    private Collider coll;

    //ladder when climbable
    private Collider ladder;


    // Use this for initialization
    void Start () {
        climbable = false;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider>();
        //define the distance between the player and the ground normally
        distToGround = coll.bounds.extents.y;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

        //Handle Movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = rb.velocity;

        movement.x = moveHorizontal * speedH;

        if (climbable) {
            float moveVertical = Input.GetAxis("Vertical");
            movement.y = moveVertical * speedY;
            
        }
        if (!IsGrounded())
        {
            if (ladder)
            {
                Transform playerT = transform;
                Vector3 position = playerT.position;
                Vector3 ladderPos = ladder.transform.position;
                position.x = ladderPos.x;
                transform.SetPositionAndRotation(position, playerT.rotation);
                anim.SetBool("Climbing", true);
                anim.SetFloat("SpeedV", movement.y);
            }
        }
        else
        {
            anim.SetBool("Climbing", false);
        }
        rb.velocity = movement;
        
    }
    private void OnTriggerEnter(Collider theCollider)
    {
        Debug.Log("collided with a " + theCollider.tag);
        //try to get a workable object
        workableObject = theCollider.GetComponentInParent<WorkableObject>();
        if (workableObject)
        {
            workableObject.playerActive = true;
        }
        //check if its a ladder
        switch (theCollider.tag) {
            case "Ladder": MakeClimbable(theCollider);
                break;
        }
    }
    private void OnTriggerExit(Collider theCollider)
    {
        workableObject = null;
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
    

    void MakeClimbable(Collider theLadder)
    {
        ladder = theLadder;
        //turn off gravity
        rb.useGravity = false;
        //allow vertical movement
        climbable = true;
    }
    void RemoveClimbable()
    {
        ladder = null;
        rb.useGravity = true;
        climbable = false;

    }


    private bool IsGrounded(){
         return Physics.Raycast(transform.position, -Vector3.up, (float)(distToGround + 0.1));
     }

    bool IsClimbable()
    {
        return climbable;
    }
    public bool HasWorkableObject()
    {
        if (workableObject)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public WorkableObject GetWorkableObject()
    {
        return workableObject;
    }
}
