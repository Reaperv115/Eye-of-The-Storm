using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class smg : WeaponBase
{
    Ray ray;
    RaycastHit hit;

    [SerializeField]
    Transform barrel;

    public LayerMask layermask;

    TextMeshProUGUI ammoTracker;
    TextMeshProUGUI reloadIndicator;
    TextMeshProUGUI noAmmo;
    // Start is called before the first frame update
    void Start()
    {
        mag = 15;
        reserves = 120;
        originalDamage = weaponDamage = 4;
        magCapacity = 30;
        ammoTracker = GameObject.Find("ammo Tracker").GetComponent<TextMeshProUGUI>();
        noAmmo = GameObject.Find("no ammo").GetComponent<TextMeshProUGUI>();
        reloadIndicator = GameObject.Find("reload indicator").GetComponent<TextMeshProUGUI>();
        reloadIndicator.text = "";
        hasAmmo = true;
        range = 150;
    }

    // Update is called once per frame
    void Update()
    {
        ammoTracker.text = mag + "/" + reserves;

        Debug.DrawRay(barrel.position, barrel.forward * range);

        if (mag <= 0f && reserves <= 0f)
        {
            hasAmmo = false;
        }

        if (!hasAmmo)
        {
            noAmmo.text = "NO AMMO";
            reloadIndicator.text = "";
        }
        else
        {


            if (Input.GetKeyDown(KeyCode.R))
            {
                if (reserves - magCapacity <= 0)
                {
                    reserves = 0;
                    mag += (magCapacity - mag);
                }
                else
                {
                    reserves -= (magCapacity - mag);
                    mag = magCapacity;
                }

                reloadIndicator.text = "";
            }

            if (Input.GetMouseButton(0))
            {
                if (mag <= 0f)
                {
                    reloadIndicator.text = "Reload!";
                }
                else
                {
                    --mag;
                    ray = new Ray(barrel.position, barrel.forward * range);
                    if (Physics.Raycast(ray, out hit, range, layermask))
                    {
                        //Debug.Log(hit.transform.name);
                        if (hit.transform.name.Contains("e"))
                        {
                            hit.transform.gameObject.GetComponent<FireEnemy>().takeDamage(weaponDamage);
                            //Debug.Log("enemy hit");
                        }
                    }
                }

            }
        }
    }

   
}
