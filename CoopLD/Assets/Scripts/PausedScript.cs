using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedScript : MonoBehaviour {

    public bool paused;
    GameObject pausedObject;

	// Use this for initialization
	void Start () {

        paused = false;
        //pausedObject = GameObject.FindGameObjectWithTag("PausedScreen)");
        hidePaused();

	}

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
        }

        if (paused)
        {
            Time.timeScale = 0;
            //pausedObject.SetActive(true);
        }
        if (!paused)
        {
            hidePaused();
            Time.timeScale = 1;
        }

    }
    public void hidePaused()
    {
        //pausedObject.SetActive(false);
    }

	
}
