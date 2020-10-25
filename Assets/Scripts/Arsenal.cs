using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Arsenal : MonoBehaviour
{
    public GameObject[] arsenal; 
    public GameObject currentWeapon;
    public Transform hand;

    public int weaponIndex = 0;
    public int selectedWeapon = 0;
    int previousWeapon;
    int lastvalidSpot = 0;

    TextMeshProUGUI ammoTracker;

    // Start is called before the first frame update
    void Start()
    {
        arsenal = new GameObject[8];
        currentWeapon = Resources.Load<GameObject>("energy hammer");
        currentWeapon = Instantiate(currentWeapon, hand.transform.position, hand.transform.rotation, hand);
        arsenal[weaponIndex] = currentWeapon;
        lastvalidSpot = previousWeapon = weaponIndex;
        ammoTracker = GameObject.Find("ammo Tracker").GetComponent<TextMeshProUGUI>();
        selectWeapon();
        //Debug.Log(arsenal.Length);
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(weaponIndex);

        //previousWeapon = selectedWeapon;

        //scroll through arsenal
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponIndex >= arsenal.Count() - 1 || arsenal[weaponIndex + 1] == null)
            {
                previousWeapon = weaponIndex;
                weaponIndex = 0;
            }
            else
            {
                previousWeapon = weaponIndex;
                weaponIndex++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponIndex <= 0)
            {
                previousWeapon = weaponIndex;
                weaponIndex = lastvalidSpot;
            }
            else
            {
                previousWeapon = weaponIndex;
                weaponIndex--;
            }

        }

        if (previousWeapon != weaponIndex)
        {
            selectWeapon();
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<smg>()              ||
            other.gameObject.GetComponent<AR>()               ||
            other.gameObject.GetComponent<shotgun>()          ||
            other.gameObject.GetComponent<SniperRifle>()      ||
            other.gameObject.GetComponent<pistol>()           ||
            other.gameObject.GetComponent<RocketLauncher>()   ||
            other.gameObject.GetComponent<GrenadeLauncher>())
        {
            for (int i = 0; i < arsenal.Length; ++i)
            {
                if (arsenal[i] == null)
                {
                    weaponIndex = i;
                    lastvalidSpot = weaponIndex;
                    arsenal[weaponIndex] = other.gameObject;
                    currentWeapon = arsenal[weaponIndex];
                    currentWeapon.GetComponent<BoxCollider>().enabled = false;
                    currentWeapon.transform.position = hand.position;
                    currentWeapon.transform.rotation = hand.rotation;
                    currentWeapon.transform.SetParent(hand);
                    break;

                }
                if (arsenal[i].name == other.gameObject.name)
                {
                    if (other.gameObject.GetComponent<smg>())
                    {
                        ++arsenal[i].GetComponent<smg>().maxAmmo;
                        Destroy(other.gameObject);
                    }
                    if (other.gameObject.GetComponent<SniperRifle>())
                    {
                        ++arsenal[i].GetComponent<SniperRifle>().maxAmmo;
                        Destroy(other.gameObject);
                    }
                    if (other.gameObject.GetComponent<shotgun>())
                    {
                        ++arsenal[i].GetComponent<shotgun>().maxAmmo;
                        Destroy(other.gameObject);
                    }
                    if (other.gameObject.GetComponent<RocketLauncher>())
                    {
                        ++arsenal[i].GetComponent<RocketLauncher>().maxAmmo;
                        Destroy(other.gameObject);
                    }
                    if (other.gameObject.GetComponent<pistol>())
                    {
                        ++arsenal[i].GetComponent<pistol>().maxAmmo;
                        Destroy(other.gameObject);
                    }
                    if (other.gameObject.GetComponent<AR>())
                    {
                        ++arsenal[i].GetComponent<AR>().maxAmmo;
                        Destroy(other.gameObject);
                    }
                    if (other.gameObject.GetComponent<GrenadeLauncher>())
                    {
                        ++arsenal[i].GetComponent<GrenadeLauncher>().maxAmmo;
                        Destroy(other.gameObject);
                    }
                    break;
                }
            }
        }
    }

    void selectWeapon()
    {
        int i = 0;
        foreach(GameObject weapon in arsenal)
        {
            if (weapon)
            {
                if (i == weaponIndex)
                {
                    weapon.SetActive(true);
                    currentWeapon = weapon.gameObject;
                }
                else
                    weapon.SetActive(false);
                ++i;
            }
        }
    }
}
