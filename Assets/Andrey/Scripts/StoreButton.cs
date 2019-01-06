using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreButton : MonoBehaviour {

   
    public GameObject storePanel;
    public GameObject gradientPanel;

    private bool isPaused;

    void Start()
    {
        isPaused = false;
    }

    

    public void OnClickButton()
    {
        if (isPaused)
        {
            TurnOff();
            isPaused = !isPaused;
        }

        else
        {
            TurnOn();
            isPaused = !isPaused;
        }
         

    }

    private void TurnOn()
    {
        storePanel.SetActive(true);
        gradientPanel.SetActive(true);
    }
    private void TurnOff()
    {
        storePanel.SetActive(false);
        gradientPanel.SetActive(false);
    }

}
