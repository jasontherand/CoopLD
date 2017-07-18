using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBehavior : WorkableObject {

    
    public int timeToComplete = 600;
    private Renderer theRenderer;

	// Use this for initialization
	public override void Start () {
        base.Start();
        theRenderer = GetComponent<Renderer>();
        theRenderer.enabled = true;
        workable = true;
    }
	
	// Update is called once per frame
	public override void Update () {
        base.Update();

        //fix the hole if worked for workingtime
        if(timeWorking >= timeToComplete)
        {
            FixHole();
        }
    }

    private void FixHole()
    {
        workable = false;
        Debug.Log("done Working");
        theRenderer.enabled = false;
    }

    public bool BlowHole()
    {
        if (theRenderer.enabled == true)
        {
            //if already blown return false
            return false;
        }
        else
        {
            //otherwise blow open the hole and return true
            theRenderer.enabled = true;
            workable = true;
            return true;
        }
    }
}
