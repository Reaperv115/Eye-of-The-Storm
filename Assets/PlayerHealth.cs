using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100f;
    private float startHealth;
    private float armor = 100f;

    GameObject healthBar;
    GameObject armorBar;
    
    // Start is called before the first frame update
    void Start()
    {
        startHealth = health;
        healthBar = GameObject.Find("health bar");
        healthBar.transform.Find("fill").GetComponent<Image>().color = Color.red;

        armorBar = GameObject.Find("armor bar");
        armorBar.transform.Find("fill").GetComponent<Image>().color = Color.green;
    }

    public float getHealth()
    {
        return health;
    }
    public float getArmor()
    {
        return armor;
    }
    public void setHealth(float damage)
    {
        health -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.GetComponent<Slider>().value = health / startHealth;
        if (health <= 0.0f)
        {
            Debug.Log("player dead");
        }
    }
}
