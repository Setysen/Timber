using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextFade : MonoBehaviour {

    
    // Use this for initialization
    
    public void OnAnimationStart(int x)
    {
        
        GetComponent<Text>().text = '+' + x.ToString();
        
    }

    public void OnAnimationEnded()
    {
        Destroy(this.gameObject);
    }
}
