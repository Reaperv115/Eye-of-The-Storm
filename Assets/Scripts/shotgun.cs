using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shotgun : WeaponBase
{
    Ray ray;
    RaycastHit hit;

    [SerializeField]
    Transform barrel;

    //TextMeshProUGUI ammoTracker;
    TextMeshProUGUI reloadIndicator;
    TextMeshProUGUI noAmmo;

    public LayerMask layermask;

    // Start is called before the first frame update
    void Start()
    {
        mag = 30;
        reserves = 190;
        originalDamage = weaponDamage = 100;
        magCapacity = 30;
        //ammoTracker = GameObject.Find("ammo Tracker").GetComponent<TextMeshProUGUI>();
        reloadIndicator = GameObject.Find("reload indicator").GetComponent<TextMeshProUGUI>();
        noAmmo = GameObject.Find("no ammo").GetComponent<TextMeshProUGUI>();
        reloadIndicator.text = "";
        hasAmmo = true;
        range = 100;
    }

    // Update is called once per frame
    void Update()
    {
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

            if (Input.GetMouseButtonDown(0))
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
