﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCntr : MonoBehaviour {

    public int numberOfMinions;
    public float nextBonus;
    public float actualBonus;
    public int pOneCost;
    public int updateCost;
    public float updateBonus;
    public GameObject minion;//Сюда префаб  миниона с спрайтом 
    public NewGameCntr newGameCntr;//Сюда скрипт New GameCntr
    // Use this for initialization
    public GameObject objText;

    private float deltaX = 0;
    private float deltaY = 0.75f;
    private float xDelta = 0.38f;
    private Text text;
    public Transform childeTransform;

	void Start () {
        text = objText.GetComponent<Text>();
        UpdateText();
        MinionRender();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onButtonDown()// метод покупки , вызывать при нажатии кнопки
    {
        if (newGameCntr.wood >= pOneCost)
        {
            newGameCntr.wood -= pOneCost;// вычитаем очки
            pOneCost *= 2;
            actualBonus += nextBonus;//увеличиваем бонус в секунду
            numberOfMinions += 1;// увеличиваем количество миньонов
            newGameCntr.BonusInitialise();// вызываем данную функцию для учтения бонуса в секунду
            AddMinionOnScreen(); //спавним на сцене еще одного миньона 
            UpdateText();
        }
       
    }

    public void onUpdateButtonDown()
    {
        if (newGameCntr.wood >= updateCost)
        {
            newGameCntr.wood -= updateCost;
            updateCost =  Mathf.RoundToInt(1.5f * updateCost);
            actualBonus *= updateBonus;
            nextBonus *= updateBonus;
            UpdateText();
        }
    }

    public void MinionRender()//рендерим минионов относительно трансформоа ребенка  кнопки
    {

        Debug.Log("MinionRender");

        float xDelta = 0.9f;
        
            for (int i= 0; i < numberOfMinions; i++)
            {
            Debug.Log(i);
            Instantiate(minion, childeTransform.position + new Vector3(deltaX, deltaY), Quaternion.identity , childeTransform);
            if (deltaY != 0)
            {
                deltaY = 0;
            }
            else
            {
                deltaY = 0.75f;
            }
            deltaX += xDelta;
        }
    }

    private void AddMinionOnScreen()
    {
        float  xDelta = 0.9f;
        Instantiate(minion, childeTransform.position + new Vector3(deltaX, deltaY), Quaternion.identity, childeTransform);
        if (deltaY != 0)
        {
            deltaY = 0;
        }
        else
        {
            deltaY = 0.75f;
        }
        deltaX += xDelta;
    }

    public void UpdateText()
    {
        Debug.Log("Update text");
        text.text = "Cost: " + pOneCost + " Update cost: " + updateCost + " Profit: " + actualBonus ;
    }

}

