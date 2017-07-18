using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkableObject : MonoBehaviour {

    public bool playerActive;
    public bool workable;
    public int timeWorking;

	// Use this for initialization
	public virtual void Start () {
        playerActive = false;
        timeWorking = 0;
    }
	
	// Update is called once per frame
	public virtual void Update () {
        //if the player is over this workable oject
        if (playerActive)
        {
            //and they are actively working
            bool doAction = Input.GetButton("DoAction");

            if (doAction)
            {
                //add to the working timer
                timeWorking++;
            }
            else
            {
                //otherwise reset it back to 0
                timeWorking = 0;
            }
        }

    }
}
