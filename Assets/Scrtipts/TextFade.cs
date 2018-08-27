using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextFade : MonoBehaviour {

    private Vector2 moveVector;
    private System.Random rnd;
    // Use this for initialization
    public void Start()
    {
        
        rnd = new System.Random();
        moveVector = new Vector2(rnd.Next(-1,1),4);
    }

    private void Update()
    {
        transform.Translate(moveVector * 2 * Time.deltaTime);
    }

    public void OnAnimationStart(int x)
    {

        GetComponent<Text>().text = '+' + x.ToString();
        
    }

    public void OnAnimationStartN2(int x)
    {
        Text text = GetComponent<Text>();
        
        text.text = '+' + x.ToString();
        text.fontSize = 45;
        text.color = Color.green;

    }

    public void OnAnimationEnded()
    {
        Destroy(this.gameObject);
    }
}
