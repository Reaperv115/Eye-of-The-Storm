using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Arsenal : MonoBehaviour
{
    public GameObject[] arsenal; 
    public GameObject currentWeapon;
    public Transform hand;
    public Transform backpack;

    public int weaponIndex = 0;
    public int selectedWeapon;

    TextMeshProUGUI ammoTracker;

    // Start is called before the first frame update
    void Start()
    {
        arsenal = new GameObject[8];
        currentWeapon = Resources.Load<GameObject>("energy hammer");
        currentWeapon = Instantiate(currentWeapon, hand.transform.position, hand.transform.rotation, hand);
        arsenal[weaponIndex] = currentWeapon;
        ammoTracker = GameObject.Find("ammo Tracker").GetComponent<TextMeshProUGUI>();
        Debug.Log(arsenal.Length);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (currentWeapon)
        {
            if (currentWeapon.GetComponent<shotgun>())
            {
                Quaternion weaponRotation = currentWeapon.transform.rotation;
                weaponRotation = Quaternion.Euler(new Vector3(0.0f, 90f, 0.0f));
                currentWeapon.transform.rotation = weaponRotation;
                currentWeapon.transform.position = hand.position;
            }
            else
            {

                currentWeapon.transform.position = hand.position;
                currentWeapon.transform.rotation = hand.rotation;
            }
        }

        

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponIndex == arsenal.Length - 1)
            {
                weaponIndex = 0;
                currentWeapon = arsenal[weaponIndex];
                if (currentWeapon)
                {
                    if (currentWeapon.GetComponent<AR>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<AR>().ammo.ToString() + '/' + currentWeapon.GetComponent<AR>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<smg>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<smg>().ammo.ToString() + '/' + currentWeapon.GetComponent<smg>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<RocketLauncher>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<RocketLauncher>().ammo.ToString() + '/' + currentWeapon.GetComponent<RocketLauncher>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<GrenadeLauncher>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<GrenadeLauncher>().ammo.ToString() + '/' + currentWeapon.GetComponent<GrenadeLauncher>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<pistol>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<pistol>().ammo.ToString() + '/' + currentWeapon.GetComponent<pistol>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<shotgun>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<shotgun>().ammo.ToString() + '/' + currentWeapon.GetComponent<shotgun>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<SniperRifle>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<SniperRifle>().ammo.ToString() + '/' + currentWeapon.GetComponent<SniperRifle>().maxAmmo.ToString();
                    }
                }
            }
            else
            {
                weaponIndex++;
                currentWeapon = arsenal[weaponIndex];
                if (currentWeapon)
                {
                    if (currentWeapon.GetComponent<AR>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<AR>().ammo.ToString() + '/' + currentWeapon.GetComponent<AR>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<smg>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<smg>().ammo.ToString() + '/' + currentWeapon.GetComponent<smg>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<RocketLauncher>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<RocketLauncher>().ammo.ToString() + '/' + currentWeapon.GetComponent<RocketLauncher>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<GrenadeLauncher>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<GrenadeLauncher>().ammo.ToString() + '/' + currentWeapon.GetComponent<GrenadeLauncher>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<pistol>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<pistol>().ammo.ToString() + '/' + currentWeapon.GetComponent<pistol>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<shotgun>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<shotgun>().ammo.ToString() + '/' + currentWeapon.GetComponent<shotgun>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<SniperRifle>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<SniperRifle>().ammo.ToString() + '/' + currentWeapon.GetComponent<SniperRifle>().maxAmmo.ToString();
                    }
                }
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weaponIndex == 0)
            {
                weaponIndex = arsenal.Length - 1;
                currentWeapon = arsenal[weaponIndex];
                if (currentWeapon)
                {
                    if (currentWeapon.GetComponent<AR>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<AR>().ammo.ToString() + '/' + currentWeapon.GetComponent<AR>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<smg>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<smg>().ammo.ToString() + '/' + currentWeapon.GetComponent<smg>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<RocketLauncher>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<RocketLauncher>().ammo.ToString() + '/' + currentWeapon.GetComponent<RocketLauncher>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<GrenadeLauncher>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<GrenadeLauncher>().ammo.ToString() + '/' + currentWeapon.GetComponent<GrenadeLauncher>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<pistol>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<pistol>().ammo.ToString() + '/' + currentWeapon.GetComponent<pistol>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<shotgun>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<shotgun>().ammo.ToString() + '/' + currentWeapon.GetComponent<shotgun>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<SniperRifle>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<SniperRifle>().ammo.ToString() + '/' + currentWeapon.GetComponent<SniperRifle>().maxAmmo.ToString();
                    }
                }
            }
            else
            {
                weaponIndex--;
                currentWeapon = arsenal[weaponIndex];
                if (currentWeapon)
                {
                    if (currentWeapon.GetComponent<AR>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<AR>().ammo.ToString() + '/' + currentWeapon.GetComponent<AR>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<smg>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<smg>().ammo.ToString() + '/' + currentWeapon.GetComponent<smg>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<RocketLauncher>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<RocketLauncher>().ammo.ToString() + '/' + currentWeapon.GetComponent<RocketLauncher>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<GrenadeLauncher>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<GrenadeLauncher>().ammo.ToString() + '/' + currentWeapon.GetComponent<GrenadeLauncher>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<pistol>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<pistol>().ammo.ToString() + '/' + currentWeapon.GetComponent<pistol>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<shotgun>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<shotgun>().ammo.ToString() + '/' + currentWeapon.GetComponent<shotgun>().maxAmmo.ToString();
                    }
                    if (currentWeapon.GetComponent<SniperRifle>())
                    {
                        ammoTracker.text = currentWeapon.GetComponent<SniperRifle>().ammo.ToString() + '/' + currentWeapon.GetComponent<SniperRifle>().maxAmmo.ToString();
                    }
                }
            }
        }
        else
        {
            if (currentWeapon)
            {
                if (currentWeapon.GetComponent<AR>())
                {
                    ammoTracker.text = currentWeapon.GetComponent<AR>().ammo.ToString() + '/' + currentWeapon.GetComponent<AR>().maxAmmo.ToString();
                }
                if (currentWeapon.GetComponent<smg>())
                {
                    ammoTracker.text = currentWeapon.GetComponent<smg>().ammo.ToString() + '/' + currentWeapon.GetComponent<smg>().maxAmmo.ToString();
                }
                if (currentWeapon.GetComponent<RocketLauncher>())
                {
                    ammoTracker.text = currentWeapon.GetComponent<RocketLauncher>().ammo.ToString() + '/' + currentWeapon.GetComponent<RocketLauncher>().maxAmmo.ToString();
                }
                if (currentWeapon.GetComponent<GrenadeLauncher>())
                {
                    ammoTracker.text = currentWeapon.GetComponent<GrenadeLauncher>().ammo.ToString() + '/' + currentWeapon.GetComponent<GrenadeLauncher>().maxAmmo.ToString();
                }
                if (currentWeapon.GetComponent<pistol>())
                {
                    ammoTracker.text = currentWeapon.GetComponent<pistol>().ammo.ToString() + '/' + currentWeapon.GetComponent<pistol>().maxAmmo.ToString();
                }
                if (currentWeapon.GetComponent<shotgun>())
                {
                    ammoTracker.text = currentWeapon.GetComponent<shotgun>().ammo.ToString() + '/' + currentWeapon.GetComponent<shotgun>().maxAmmo.ToString();
                }
                if (currentWeapon.GetComponent<SniperRifle>())
                {
                    ammoTracker.text = currentWeapon.GetComponent<SniperRifle>().ammo.ToString() + '/' + currentWeapon.GetComponent<SniperRifle>().maxAmmo.ToString();
                }
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
                    arsenal[weaponIndex] = other.gameObject;
                    currentWeapon = arsenal[weaponIndex];
                    currentWeapon.GetComponent<BoxCollider>().enabled = false;
                    break;

                }
                if (arsenal[i].name == other.gameObject.name)
                {
                    if (other.gameObject.GetComponent<smg>())
                    {
                        ++arsenal[i].GetComponent<smg>().ammo;
                        Destroy(other.gameObject);
                    }
                    if (other.gameObject.GetComponent<SniperRifle>())
                    {
                        ++arsenal[i].GetComponent<SniperRifle>().ammo;
                        Destroy(other.gameObject);
                    }
                    if (other.gameObject.GetComponent<shotgun>())
                    {
                        ++arsenal[i].GetComponent<shotgun>().ammo;
                        Destroy(other.gameObject);
                    }
                    if (other.gameObject.GetComponent<RocketLauncher>())
                    {
                        ++arsenal[i].GetComponent<RocketLauncher>().ammo;
                        Destroy(other.gameObject);
                    }
                    if (other.gameObject.GetComponent<pistol>())
                    {
                        ++arsenal[i].GetComponent<pistol>().ammo;
                        Destroy(other.gameObject);
                    }
                    if (other.gameObject.GetComponent<AR>())
                    {
                        ++arsenal[i].GetComponent<AR>().ammo;
                        Destroy(other.gameObject);
                    }
                    if (other.gameObject.GetComponent<GrenadeLauncher>())
                    {
                        ++arsenal[i].GetComponent<GrenadeLauncher>().ammo;
                        Destroy(other.gameObject);
                    }
                    break;
                }
            }
        }
    }
}
