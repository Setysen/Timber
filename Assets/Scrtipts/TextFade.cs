using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextFade : MonoBehaviour {

    
    // Use this for initialization
    
    public void OnAnimationStart(int x)
    {
        
        GetComponent<Text>().text = '+' + x.ToString();
<<<<<<< HEAD
      //  this.GetComponent<Animation>().Play();
=======
        
>>>>>>> parent of 81da12d... исправил проблему с пнями, добавил поощерение за вырубку одного блока
    }

    public void OnAnimationEnded()
    {
        Destroy(this.gameObject);
    }
}
