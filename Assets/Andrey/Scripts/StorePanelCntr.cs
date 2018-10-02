using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePanelCntr : MonoBehaviour
{

    public float maxX;
    public float minX;

    //public bool stop = false;
    public GameObject storePanel;
    float speed = 10f;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x >= minX && transform.position.x <= maxX)
            transform.Translate(Vector3.up* Input.GetAxis("Vertical") * speed * Time.deltaTime );
        
    }
}
