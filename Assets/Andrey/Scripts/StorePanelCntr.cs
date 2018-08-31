using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePanelCntr : MonoBehaviour {

    public bool stop1 = false; // остановка по нижней границе
    public bool stop2 = false; // остановка по верхней границе
    public GameObject storePanel; // панель с кнопками
    public float speed = 3f; // скорость движения панели с кнопками
    public RectTransform coords; // отсюда берём верхнюю и нижнюю границу панели с кнопками

	void Start () 
    {
	
	}
	
	void Update () 
    {
        coords = GetComponent<RectTransform>();
        if (coords.offsetMin[1] >= -60)//bottom   //если координаты нижней границы StorePanel больше, то останавливаемся
        {
            stop1 = true;
        }
        else if (true)  // если первый if не выполняется, то нас всё устраивает
        {
            stop1 = false;
        }

        if (coords.offsetMax[1] <= 3f)//Top   //если координаты верхней границы StorePanel меньше, то останавливаемся
        {
            stop2 = true;
        }
        else if (true) // если первый if не выполняется, то нас всё устраивает
        {
            stop2 = false;
        }

        if (Input.GetKey(KeyCode.S) && stop1 == false)
        {
            storePanel.transform.Translate(0, speed* Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.W) && stop2 == false)
        {
            storePanel.transform.Translate(0, -1f * speed * Time.deltaTime, 0);
        }
	}
}
