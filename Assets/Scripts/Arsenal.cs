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
    public List<GameObject> powerups;
    public GameObject currentWeapon;
    public Transform hand;

    public int weaponIndex = 0;
    public int selectedWeapon = 0;
    int powerupsIndex = 0;
    int previousWeapon;
    int lastvalidSpot = 0;

    float powerupTimer = 20f;

    bool damageMultiplied = false, pointsDoubled = false;

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
        //Extra Damage
        if (damageMultiplied)
        {
            powerupTimer -= Time.deltaTime;
            Debug.Log(powerupTimer);
            if (powerupTimer <= 0f)
            {
                for (int i = 0; i < arsenal.Length; ++i)
                {
                    if (arsenal[i] == null)
                    {
                        break;
                    }
                    else
                    {
                        if (arsenal[i].GetComponent<EnergyHammer>())
                        {
                            arsenal[i].GetComponent<EnergyHammer>().weaponDamage = arsenal[i].GetComponent<EnergyHammer>().originalDamage;
                            Debug.Log("energy hammer nerfed");
                        }
                        if (arsenal[i].GetComponent<AR>())
                        {
                            arsenal[i].GetComponent<AR>().weaponDamage = arsenal[i].GetComponent<AR>().originalDamage;
                            Debug.Log("AR damage nerfed");
                        }
                        if (arsenal[i].GetComponent<smg>())
                        {
                            arsenal[i].GetComponent<smg>().weaponDamage = arsenal[i].GetComponent<smg>().originalDamage;
                            Debug.Log("smg damage nerfed");
                        }
                        if (arsenal[i].GetComponent<pistol>())
                        {
                           arsenal[i].GetComponent<pistol>().weaponDamage = arsenal[i].GetComponent<pistol>().originalDamage;
                            Debug.Log("pistol damage nerfed");
                        }
                        if (arsenal[i].GetComponent<shotgun>())
                        {
                            arsenal[i].GetComponent<shotgun>().weaponDamage = arsenal[i].GetComponent<shotgun>().originalDamage;
                            Debug.Log("shotgun damage nerfed");
                        }
                        if (arsenal[i].GetComponent<GrenadeLauncher>())
                        {
                            arsenal[i].GetComponent<GrenadeLauncher>().weaponDamage = arsenal[i].GetComponent<GrenadeLauncher>().originalDamage;
                            Debug.Log("grenadelauncher damage nerfed");
                        }
                        if (arsenal[i].GetComponent<RocketLauncher>())
                        {
                            arsenal[i].GetComponent<RocketLauncher>().weaponDamage = arsenal[i].GetComponent<RocketLauncher>().originalDamage;
                            Debug.Log("rocket launcher damage nerfed");
                        }
                        if (arsenal[i].GetComponent<SniperRifle>())
                        {
                            arsenal[i].GetComponent<SniperRifle>().weaponDamage = arsenal[i].GetComponent<SniperRifle>().originalDamage;
                            Debug.Log("sniper rifle damage nerfed");
                        }
                    }


                }
                damageMultiplied = false;
                powerupTimer = 20f;
            }
        }
        //Invulnerability
        if (GetComponent<PlayerHealth>().isInvulnerable)
        {
            powerupTimer -= Time.deltaTime;
            Debug.Log(powerupTimer);
            if (powerupTimer <= 0.0f)
            {
                GetComponent<PlayerHealth>().isInvulnerable = false;
                powerupTimer = 20f;
            }
        }
        //Double Points
        if (pointsDoubled)
        {
            powerupTimer -= Time.deltaTime;
            Debug.Log(powerupTimer);
            if (powerupTimer <= 0.0f)
            {
                GetComponent<PlayerScore>().pointsperKill = 1;
                pointsDoubled = false;
                powerupTimer = 20f;
            }
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (powerups.Count <= 0)
            {
                Debug.Log("you dont currently have any powerups");
            }
            else
            {
                switch (powerups[powerupsIndex].name)
                {
                    case "Extra Damage":
                        Debug.Log("just used a powerup");
                        powerups[powerupsIndex].GetComponent<ExtraDamage>().Effect();
                        damageMultiplied = true;
                        Destroy(powerups[powerupsIndex]);
                        powerups.Remove(powerups[powerupsIndex]);
                        if (powerups.Count == 0)
                        {
                            Debug.Log("no more powerups");
                        }
                        break;
                    case "Invulnerability":
                        powerups[powerupsIndex].GetComponent<Invulnerability>().Effect();
                        Destroy(powerups[powerupsIndex]);
                        powerups.Remove(powerups[powerupsIndex]);
                        if (powerups.Count == 0)
                        {
                            Debug.Log("no more powerups");
                        }
                        break;
                    case "Double Points":
                        powerups[powerupsIndex].GetComponent<DoublePoints>().Effect();
                        pointsDoubled = true;
                        Destroy(powerups[powerupsIndex]);
                        powerups.Remove(powerups[powerupsIndex]);
                        if (powerups.Count == 0)
                        {
                            Debug.Log("no more powerups");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

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
        //if the player collides with a weapon
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

        //if the player collides with a powerup
        //Debug.Log(other.tag);
        if (other.CompareTag("powerup"))
        {
            Debug.Log("picked up powerup");
            powerups.Add(other.gameObject);
            other.gameObject.SetActive(false);
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
