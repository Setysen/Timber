using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpCntr : MonoBehaviour {

    private bool canIMove;

	// Use this for initialization
	void Start () {
        canIMove = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (canIMove) transform.Translate(Vector2.left * Time.deltaTime * 10);
	}

    public void dvigaisyaYobaniyPen(bool x)
    {
        canIMove = x;
    }

}
