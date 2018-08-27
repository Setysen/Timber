using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewNewTree : MonoBehaviour {

    public GameObject Block;
    public GameObject Crone;
    public GameObject Roots;
    
    public GameObject stump;//кидаем сюда пень
    public NewGameCntr newGameCntr;
    public ParticleSystem steamParticle;

    private Animation hitTreeAnim;
    private Transform thisTransform;//для кеширования transform
    private int quantityBlocks;//число блоков 
    private int actualBlock = 1;// актуальный блок
    private float position = 0f;
    private GameObject[] blocksArr;// массив блоков

    private void Awake()
    {
        hitTreeAnim = GetComponent<Animation>();//кешируем анимацию
        thisTransform = this.GetComponent<Transform>();//кешируем     
    }

    void Start()
    {
        quantityBlocks = Random.Range(1, 10) + 2;// задаем случайное число, отвечающее за количество блоков
        blocksArr = new GameObject[quantityBlocks];// инициализируем массив блоков 

        blocksArr[0] = Instantiate(Roots, new Vector3(thisTransform.position.x, thisTransform.position.y + position), Quaternion.identity);//создаем корни
        blocksArr[0].transform.parent = thisTransform;// делаем дерево родителем корней, чтобы менять позицию корней вместе с позицией дерева 



        for (int i = 1; i < quantityBlocks - 1; i++)// создаем блокки 
        {
            position += 1.5f;
            blocksArr[i] = Instantiate(Block, new Vector3(thisTransform.position.x, thisTransform.position.y + position), Quaternion.identity);
            blocksArr[i].transform.parent = transform;// делаем дерево родителем блока
        }

        position += 1.5f;

        blocksArr[quantityBlocks - 1] = Instantiate(Crone, new Vector3(thisTransform.position.x, thisTransform.position.y + position), Quaternion.identity);// создаем крону
        blocksArr[quantityBlocks - 1].transform.parent = thisTransform;// делаем дерево родителем кроны

        position = 0;
    }


    public void OnHit()
    {
        hitTreeAnim.Play("onHitTree");// запускаем анимацию
    }

    public void OnBlockDestroyed() 
    {
        Destroy(blocksArr[actualBlock]);// позже вставить сюда запуск анимации блока 
        actualBlock++;

        Instantiate(steamParticle, new Vector2(0, -1.5f), Quaternion.identity);

        if (actualBlock == quantityBlocks)
            newGameCntr.OnTreeDestroyed();

        for (int i = actualBlock; i < quantityBlocks; i++)
        {
            blocksArr[i].transform.position = new Vector3(blocksArr[i].transform.position.x, blocksArr[i].transform.position.y - 1.5f, 0);
        }


    }
}
