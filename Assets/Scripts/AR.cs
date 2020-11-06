

using TMPro;
using UnityEditor.Build.Content;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AR : WeaponBase
{
    Ray ray;
    RaycastHit hit;

    [SerializeField]
    Transform barrel;

    TextMeshProUGUI ammoTracker;
    TextMeshProUGUI reloadIndicator;
    TextMeshProUGUI noAmmo;

    public LayerMask layermask;
    // Start is called before the first frame update
    void Start()
    {
        mag = 30;
        reserves = 190;
        magCapacity = 30;
        reservesCapacity = 190;
        originalDamage = weaponDamage = 7;
        ammoTracker = GameObject.Find("ammo Tracker").GetComponent<TextMeshProUGUI>();
        reloadIndicator = GameObject.Find("reload indicator").GetComponent<TextMeshProUGUI>();
        noAmmo = GameObject.Find("no ammo").GetComponent<TextMeshProUGUI>();
        reloadIndicator.text = "";
        hasAmmo = true;
        range = 300;
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
                if (reserves - magCapacity <= 0f)
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
