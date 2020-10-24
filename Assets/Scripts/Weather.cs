using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public enum Elements
    {
        Fire = 0,
        Earth,
        Wind,
        Water
    }public Elements elements;
    Color[] elementColors = { Color.red, Color.gray, Color.yellow, Color.blue };

    Color currelementColor;

    [SerializeField]
    Material currentElement;

    float elementTimer = 10.0f;

    public Elements getElement()
    {
        return elements;
    }

    public void setElement(Elements element)
    {
        elements = element;
    }
    // Start is called before the first frame update
    void Start()
    {
        //int randomElement = Random.Range(0, elementColors.Length);
        //currentElement.color = elementColors[randomElement];
        //Resources.Load<GameObject>("Enemy").GetComponent<MeshRenderer>().material = currentElement;
    }

    // Update is called once per frame
    void Update()
    {
        //if (elementTimer <= 0.0f)
        //{
        //    elementTimer = 10.0f;
        //    int randomElement = Random.Range(0, elementColors.Length);
        //    currentElement.color = elementColors[randomElement];
        //    GameObject.Find("Enemy(Clone)").GetComponent<MeshRenderer>().material = currentElement;
        //}
        //elementTimer -= Time.deltaTime;
        //currentElement.color = elementColors[(int)Elements.Fire];
        //GameObject.Find("Zombie(Clone)").GetComponent<MeshRenderer>().material.color = currentElement.color;
    }
}
