using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreButton : MonoBehaviour {

    public bool isPaused;
    public GameObject storePanel;

    void Start()
    {
    }

    void Update()
    {

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
            storePanel.SetActive(true);
        }
        else if (isPaused == false)
        {
            storePanel.SetActive(false);
        }
    }

    public void StButton()
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
