using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCntr : MonoBehaviour {

    public void OnAnimationEnded()
    {
        Destroy(this.gameObject);
    }
}
