using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBehavior : MonoBehaviour {

    public bool working;
    private int timer;
    public int timerlength = 600;
    private Renderer renderer;
    private int workingTimer;
    public int workingTime = 100;

	// Use this for initialization
	void Start () {
        timer = 0;
        workingTimer = 0;
        renderer = GetComponent<Renderer>();
        renderer.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        timer++;

        //create the hole after timerlength has passed
        if(timer >= timerlength)
        {
            timer = 0;
            renderer.enabled = true;
        }

        //fix the hole if worked for workingtime

        if (working)
        {
            if (workingTimer >= workingTime)
            {
                Debug.Log("done Working");
                renderer.enabled = false;
                timer = 0;
            }
            else
            {
                workingTimer++;
            }
        }
        else
        {
            workingTimer = 0;
        }
    }
}
