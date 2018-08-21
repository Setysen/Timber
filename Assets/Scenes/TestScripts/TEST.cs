using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TEST : MonoBehaviour {


    public int damage;
    public Text text;
    private int score;


	// Use this for initialization
	void Start () {
        score = 0;
        text.text = score.ToString();
        damage = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        score += damage;
        text.text = score.ToString();

    }
}
