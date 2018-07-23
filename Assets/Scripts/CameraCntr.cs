
using UnityEngine;

public class CameraCntr : MonoBehaviour {


    public GameObject player;
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
	}
}
