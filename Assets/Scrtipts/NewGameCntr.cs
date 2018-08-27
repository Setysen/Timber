using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameCntr : MonoBehaviour {

    public int wood;//считаем очки дерева
    public GameObject tree;// префаб дерева
    public GameObject[] treeArr;// массив из двух деревльев // первое- в центре, второе- справа
    //public Tree[] TreeArr;
    public GameObject stump;// префаб пня
    public float moveSpeed;// 
    public bool canBGMove = false;// флаг, который разрешает, или запрещает всему двигаться
    public Text text;// кидаем сюда текст UI чтобы его потом изменять
    public GameObject clickText;
<<<<<<< HEAD
 //   public Canvas canvas;


    // private Random rnd;
    private int hp;
    private NewNewTree mainTree;// ""
    //private GameObject hiddenText;
    // Use this for initialization
=======
    public GameObject[] stumpArr; 


    private int hp;
    private NewNewTree mainTree;
    
>>>>>>> parent of 81da12d... исправил проблему с пнями, добавил поощерение за вырубку одного блока
    private void Awake()// этот метод вызывается при загрузке сцены 
    {
        treeArr = new GameObject[2];// создаем массив из двух деревьев
        treeArr[0] = Instantiate(tree, new Vector3(0, -4, 0), Quaternion.identity);
        treeArr[1] = Instantiate(tree, new Vector3(6, -4, 0), Quaternion.identity); // инициализируем массив
        mainTree = treeArr[0].GetComponent<NewNewTree>();  // привязываем скрипт первого/ центрального дерева, чтобы вызывать методы данного дерева
        mainTree.newGameCntr = this;// привязываем GameCntr к центральному дереву, чтобы оно вызывало методы GameCntr
        hp = 3;
<<<<<<< HEAD
=======
        canBGMove = false;
>>>>>>> parent of 81da12d... исправил проблему с пнями, добавил поощерение за вырубку одного блока
    }

   
	
	// Update is called once per frame
	void Update ()
    {
        if (canBGMove) // если флаг canBGMove == true , то двигаем обв дерева влкво
        {
            treeArr[0].transform.Translate(moveSpeed * Vector2.left * Time.deltaTime);
            treeArr[1].transform.Translate(moveSpeed * Vector2.left * Time.deltaTime);
        }
        if (treeArr[0].transform.position.x < 0) // если центральное дерево встает в центр, убираем флаг canBGMove 
        {
            treeArr[0].transform.position = new Vector3(0, -4, 0);
            canBGMove = false;
        }
	}

    private void OnMouseDown() // при нажатии
    {
        hp -= 1;
        wood += 1;



<<<<<<< HEAD
        Instantiate(clickText, this.transform).GetComponent<TextFade>().OnAnimationStart(1) ;// позже вставить сюда количество срубленного дерева за один клик //создаем текст, вылетающий при клике
=======
        Instantiate(clickText, this.transform).GetComponent<TextFade>().OnAnimationStart(x: 1) ;// позже вставить сюда количество срубленного дерева за один клик //создаем текст, вылетающий при клике
>>>>>>> parent of 81da12d... исправил проблему с пнями, добавил поощерение за вырубку одного блока
        


        text.text = wood.ToString(); // изменяем текст 
        Debug.Log(wood); // пишем в консоль 
        mainTree.OnHit();// запускаем анимацию дерева
        if (hp == 0)
        {
            mainTree.OnBlockDestroyed(); // при вырубке блока вызываем соответствующий метод дерева
            hp = 3;
        }
    }

    public void OnTreeDestroyed()// метод, вызывемый деревом, при смерти. 
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
