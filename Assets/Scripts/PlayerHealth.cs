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
    public bool isInvulnerable = false;

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
    public void changeHealth(float damage)
    {
        health -= damage;
    }

    public void setHealth(float newHealth)
    {
        health = newHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvulnerable)
        {
            health = 100f;
        }
        healthBar.GetComponent<Slider>().value = health / startHealth;
        if (health <= 0.0f)
        {
            Debug.Log("player dead");
        }
    }
}
