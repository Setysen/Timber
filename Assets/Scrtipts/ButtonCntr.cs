using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCntr : MonoBehaviour {

  //  public int numberOfMinions;
    public GameObject minion;//Сюда префаб  миниона с спрайтом 
    public NewGameCntr newGameCntr;//Сюда скрипт New GameCntr
    // Use this for initialization
    public GameObject objText;


    public int N;
    public float S;
    public int profitPerOne;
    public int oneUnitCost;
    public int updateSCost;
    public int allProfit;


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
	
    public void onButtonDown()// метод покупки , вызывать при нажатии кнопки
    {
        if (newGameCntr.wood/100 >= System.Convert.ToUInt64(oneUnitCost))
        {
            newGameCntr.wood -= System.Convert.ToUInt64(oneUnitCost*100);// вычитаем очки
            oneUnitCost =System.Convert.ToInt16( oneUnitCost * 1.15);

            N += 1;// увеличиваем количество миньонов
            updateAllProfit();//метод, изменяющий AllProfit
            newGameCntr.BonusInitialise();// вызываем данную функцию для учтения бонуса в секунду
            AddMinionOnScreen(); //спавним на сцене еще одного миньона 
            UpdateText();
        }
       
    }
    
    public void onUpdateButtonDown()//метод покупки улучшения
    {
        if (newGameCntr.wood >=System.Convert.ToUInt64(100 * updateSCost))
        {
            newGameCntr.wood -= System.Convert.ToUInt64(100 * updateSCost);
            updateSCost =  Mathf.RoundToInt(1.5f * updateSCost);
            S *= 1.5f;
            UpdateText();
        }
    }

    private void updateAllProfit()
    {
        allProfit =Mathf.RoundToInt( N * S * profitPerOne/10);
    }
    
    public void MinionRender()//рендерим минионов относительно трансформоа ребенка  кнопки
    {

        Debug.Log("MinionRender");

        float xDelta = 0.9f;
        
            for (int i= 0; i < N; i++)
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
        text.text =  " Another one cost: " + oneUnitCost + " Profit: " + allProfit/100 + '.' + allProfit%100 + "  Update cost: " + updateSCost  ;
    }

}

