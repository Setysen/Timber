using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCntr : MonoBehaviour {

    public int numberOfMinions;
    public float nextBonus;
    public float actualBonus;
    public int updateCoast;
    public GameObject minion;//Сюда префаб  миниона с спрайтом 
    public NewGameCntr newGameCntr;//Сюда скрипт New GameCntr
    // Use this for initialization



    private float xDelta = 0.38f;
    
    private Transform parentOfThisButtomTransform;

	void Start () {
        parentOfThisButtomTransform = GetComponent<Transform>().parent.transform; //находим трансформ родителя, чтобы потом спавнить миниона
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onButtonDown()// метод покупки , вызывать при нажатии кнопки
    {
        if (newGameCntr.wood >= updateCoast)
        {
            newGameCntr.wood -= updateCoast;// вычитаем очки
            updateCoast = Mathf.RoundToInt(updateCoast * 1.6f);// умножаем и округляем до целого
            actualBonus += nextBonus;//увеличиваем бонус в секунду
            numberOfMinions += 1;// увеличиваем номер миньонов
            newGameCntr.BonusInitialise();// вызываем данную функцию для учтения бонуса в секунду
            MinionRender();
        }
    }

    public void MinionRender()//рендерим минионов относительно трансформоа родителя кнопки
    {
        float xDelta = 0.38f;
        float deltaX = 0;
        float deltaY = 0;
            for (int i= 0; i < numberOfMinions; i++)
        {
            Instantiate(minion,  new Vector2(deltaX, deltaY), Quaternion.identity , parentOfThisButtomTransform);
            if (deltaY != 0)
            {
                deltaY = 0;
            }
            else
            {
                deltaY = 0.29f;
            }
            deltaX += xDelta;
        }
    }

}
