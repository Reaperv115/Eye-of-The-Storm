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

    //TextMeshProUGUI ammoTracker;
    TextMeshProUGUI reloadIndicator;
    TextMeshProUGUI noAmmo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = 15f;
        maxAmmo = 120f;
        damage = 100f;
        magCapacity = 30f;
        //ammoTracker = GameObject.Find("ammo Tracker").GetComponent<TextMeshProUGUI>();
        noAmmo = GameObject.Find("no ammo").GetComponent<TextMeshProUGUI>();
        reloadIndicator = GameObject.Find("reload indicator").GetComponent<TextMeshProUGUI>();
        reloadIndicator.text = "";
        hasAmmo = true;
        range = 150;
    }

    // Update is called once per frame
    void Update()
    {
        //ammoTracker.text = ammo + "/" + maxAmmo;

        Debug.DrawRay(barrel.position, barrel.forward * range);

        if (ammo <= 0f && maxAmmo <= 0f)
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
                if (maxAmmo - magCapacity <= 0f)
                {
                    maxAmmo = 0f;
                    ammo += (magCapacity - ammo);
                }
                else
                {
                    maxAmmo -= (magCapacity - ammo);
                    ammo = magCapacity;
                }

                reloadIndicator.text = "";
            }

            if (Input.GetMouseButton(0))
            {
                if (ammo <= 0f)
                {
                    reloadIndicator.text = "Reload!";
                }
                else
                {
                    --ammo;
                    ray = new Ray(barrel.position, barrel.forward * range);
                    if (Physics.Raycast(ray, out hit, range, layermask))
                    {
                        Debug.Log(hit.transform.name);
                        if (hit.transform.name.Contains("e"))
                        {
                            Destroy(hit.transform.gameObject);
                            //hit.transform.gameObject.GetComponent<FireEnemy>().fAI = FireEnemy.FireAI.gethit;
                            Debug.Log("enemy hit");
                        }
                    }
                }

            }
        }
    }

   
}
