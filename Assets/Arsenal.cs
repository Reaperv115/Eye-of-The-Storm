using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Arsenal : MonoBehaviour
{
    public GameObject[] arsenal; 
    public GameObject currentWeapon;
    public Transform hand;
    public Transform backpack;

    public int weaponIndex = 0;
    public int selectedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        arsenal = new GameObject[8];
        currentWeapon = Resources.Load<GameObject>("energy hammer");
        currentWeapon = Instantiate(currentWeapon, hand.transform.position, hand.transform.rotation, hand);
        arsenal[weaponIndex] = currentWeapon;

        Debug.Log(arsenal.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWeapon)
        {
            currentWeapon.transform.position = hand.position;
            currentWeapon.transform.rotation = hand.rotation;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponIndex == arsenal.Length - 1)
            {
                weaponIndex = 0;
                currentWeapon = arsenal[weaponIndex];
            }
            else
            {
                weaponIndex++;
                currentWeapon = arsenal[weaponIndex];
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponIndex == 0)
            {
                weaponIndex = arsenal.Length - 1;
                currentWeapon = arsenal[weaponIndex];
            }
            else
            {
                weaponIndex--;
                currentWeapon = arsenal[weaponIndex];
            }
        }

        foreach(GameObject weapon in arsenal)
        {
            if (weapon)
            {
                if (weapon == currentWeapon)
                { }
                else
                {
                    weapon.transform.position = backpack.position;
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<smg>() || other.gameObject.GetComponent<AR>())
        {
            for (int i = 0; i < arsenal.Length; ++i)
            {
                if (arsenal[i] == null)
                {
                    weaponIndex = i;
                    arsenal[weaponIndex] = other.gameObject;
                    currentWeapon = arsenal[weaponIndex];
                    break;

                }
                if (arsenal[i].name == other.gameObject.name)
                {
                    if (other.gameObject.GetComponent<smg>())
                    {
                        ++other.GetComponent<smg>().ammo;
                        Destroy(other.gameObject);
                    }
                    else
                    {
                        ++other.GetComponent<AR>().ammo;
                        Destroy(other.gameObject);
                    }
                    break;
                }
            }
        }
    }
}
