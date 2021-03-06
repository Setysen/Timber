﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewGameCntr : MonoBehaviour {

    public int damage;
    public System.UInt64 wood;//считаем очки дерева
    public GameObject tree;// префаб дерева
    public GameObject[] treeArr;// массив из двух деревльев // первое- в центре, второе- справа
    public GameObject stump;// префаб пня
    public float moveSpeed;// 
    public bool canBGMove;// флаг, который разрешает, или запрещает всему двигаться
    public Text text;// кидаем сюда текст UI чтобы его потом изменять
    public GameObject clickText;
    public GameObject[] stumpArr;
    public GameObject[] buttonMinions;
    public GameObject timberMan;

    private Animator timberManAnimator;
    private System.Random rnd;
    private int hp;
    private NewNewTree mainTree;
    private System.UInt64 mainBonus;

  

    public void BonusInitialise()
    {
        foreach (GameObject button in buttonMinions)
        {
            mainBonus += System.Convert.ToUInt64(button.GetComponent<ButtonCntr>().allProfit);
        }
    }

    

    private void AddBonus()// метод будет вызываться каждые 0.1 секунды
    {
        wood +=  mainBonus;
        text.text = (wood/100).ToString() + '$';
        Debug.Log(wood);
    }

    private void Awake()// этот метод вызывается при загрузке сцены 
    {
        treeArr = new GameObject[2];// создаем массив из двух деревьев
        treeArr[0] = Instantiate(tree, new Vector3(0, -4, 0), Quaternion.identity);
        treeArr[1] = Instantiate(tree, new Vector3(6, -4, 0), Quaternion.identity); // инициализируем массив
        mainTree = treeArr[0].GetComponent<NewNewTree>();  // привязываем скрипт первого/ центрального дерева, чтобы вызывать методы данного дерева
        mainTree.newGameCntr = this;// привязываем GameCntr к центральному дереву, чтобы оно вызывало методы GameCntr
        rnd = new System.Random();
        hp = rnd.Next(15,20);
        canBGMove = false;
        InvokeRepeating("AddBonus", 0.1f , 0.1f);// говорим вызывать бонус каждые 0.1 секунды
        timberManAnimator = timberMan.GetComponent<Animator>();
        BonusInitialise();
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

            
            stumpArr[0].GetComponent<StumpCntr>().dvigaisyaYobaniyPen(false);
            stumpArr[1].GetComponent<StumpCntr>().dvigaisyaYobaniyPen(false);

        }
	}

    private void OnMouseDown() // при нажатии
    {
        hp -= damage;
        wood += System.Convert.ToUInt64(damage*100);

        timberManAnimator.SetTrigger("Chop");

        Instantiate(clickText, this.transform).GetComponent<TextFade>().OnAnimationStart(damage);// позже вставить сюда количество срубленного дерева за один клик //создаем текст, вылетающий при клике
        


        text.text = (wood/100).ToString() + '$'; // изменяем текст 
        //Debug.Log(wood); // пишем в консоль 
        mainTree.OnHit();// запускаем анимацию дерева
        if (hp <= 0)
        {
            mainTree.OnBlockDestroyed(); // при вырубке блока вызываем соответствующий метод дерева
            
            hp = rnd.Next(8, 15);
            wood +=System.Convert.ToUInt64( damage*300);
            Instantiate(clickText, this.transform).GetComponent<TextFade>().OnAnimationStartN2(hp);// данный метод немного отличается от OnAnimationStart
        }
    }

    public void OnTreeDestroyed()// метод, вызывемый деревом, при смерти. 
    {
        timberManAnimator.SetTrigger("Jump");

        stumpArr[0].GetComponent<StumpCntr>().dvigaisyaYobaniyPen(true);
        stumpArr[1].GetComponent<StumpCntr>().dvigaisyaYobaniyPen(true);

        stumpArr[0].transform.position = new Vector2(-6, -4);
        stumpArr[1].transform.position = new Vector2(0, -4);


        Destroy(treeArr[0]);
        treeArr[0] = treeArr[1];
        mainTree = treeArr[0].GetComponent<NewNewTree>();
        mainTree.newGameCntr = this;
        treeArr[1] = Instantiate(tree, new Vector3(12, -4, 0), Quaternion.identity);
        canBGMove = true;
    }

    
}


