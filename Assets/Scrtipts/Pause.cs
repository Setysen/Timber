using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public bool isPaused;
    public GameObject menu;

	void Start () {
	}
	
	void Update () {
      
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            isPaused = false;
        }
        if (isPaused == true)
        {
            menu.SetActive(true);
        }
        else if (isPaused == false)
        {
            menu.SetActive(false);
        }	
	}

    public void PauseButton()
    { 
        if (isPaused == false)
        {
            isPaused = true;
        }
        else if (isPaused == true)
        {
            isPaused = false;
        }
    }




}
