using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : WorkableObject {

    public int timeToComplete = 200;
    private Animator theAnimator;
    // Use this for initialization
    public override void Start () {
        base.Start();
        theAnimator = GetComponent<Animator>();
        workable = true;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();

        //fix the hole if worked for workingtime
        if (timeWorking == timeToComplete)
        {
            FireCannon();
        }
    }

    private void FireCannon()
    {
        theAnimator.SetBool("Lit", true);
    }

}
