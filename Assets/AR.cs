

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

    public LayerMask layermask;
    // Start is called before the first frame update
    void Start()
    {
        ammo = 30f;
        maxAmmo = 190f;
        damage = 100f;
        ammoTracker = GameObject.Find("ammo Tracker").GetComponent<TextMeshProUGUI>();
        reloadIndicator = GameObject.Find("reload indicator").GetComponent<TextMeshProUGUI>();
        reloadIndicator.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        ammoTracker.text = ammo + "/" + maxAmmo;

        if (Input.GetKey(KeyCode.R))
        {
            maxAmmo -= (magCapacity - ammo);
            ammo = magCapacity;
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
                ray = new Ray(barrel.position, barrel.forward);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.name.Contains("o"))
                    {
                        hit.transform.gameObject.GetComponent<FireEnemy>().takeDamage(damage);
                        Debug.Log("enemy hit");
                    }
                }
            }
            
        }
    }

    
}
