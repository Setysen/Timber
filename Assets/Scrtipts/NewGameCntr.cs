using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameCntr : MonoBehaviour {

    public int wood;
    public GameObject tree;
    public GameObject[] treeArr;
    //public Tree[] TreeArr;
    public GameObject stump;
    public float moveSpeed;
    public bool canBGMove = false;
    public Text text;


    // private Random rnd;
    private int hp;
    private NewNewTree mainTree;

    // Use this for initialization
    private void Awake()
    {
        treeArr = new GameObject[2];
        treeArr[0] = Instantiate(tree, new Vector3(0, -4, 0), Quaternion.identity);
        treeArr[1] = Instantiate(tree, new Vector3(6, -4, 0), Quaternion.identity);
        mainTree = treeArr[0].GetComponent<NewNewTree>();
        mainTree.newGameCntr = this;
        hp = 3;
    }

    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (canBGMove)
        {
            treeArr[0].transform.Translate(moveSpeed * Vector2.left * Time.deltaTime);
            treeArr[1].transform.Translate(moveSpeed * Vector2.left * Time.deltaTime);
        }
        if (treeArr[0].transform.position.x < 0)
        {
            treeArr[0].transform.position = new Vector3(0, -4, 0);
            canBGMove = false;
        }
	}

    private void OnMouseDown()
    {
        hp -= 1;
        wood += 1;
        text.text = wood.ToString();
        Debug.Log(wood);
        mainTree.OnHit();
        if (hp == 0)
        {
            mainTree.OnBlockDestroyed();
            hp = 3;
        }
    }

    public void OnTreeDestroyed()
    {
        Instantiate(stump, new Vector3(0, -4, 0), Quaternion.identity);
        Destroy(treeArr[0]);
        treeArr[0] = treeArr[1];
        mainTree = treeArr[0].GetComponent<NewNewTree>();
        mainTree.newGameCntr = this;
        treeArr[1] = Instantiate(tree, new Vector3(12, -4, 0), Quaternion.identity);
        canBGMove = true;
    }
}
