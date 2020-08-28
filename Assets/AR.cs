

using UnityEngine;

public class AR : WeaponBase
{
    Ray ray;
    RaycastHit hit;

    [SerializeField]
    Transform barrel;
    // Start is called before the first frame update
    void Start()
    {
        ammo = 30f;
        maxAmmo = 190f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(barrel.transform.position, barrel.transform.forward);
        if (Input.GetMouseButtonDown(0))
        {
            ray = new Ray(barrel.position, barrel.forward);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "enemy")
                {
                    Debug.Log("enemy hit");
                }
            }
        }
    }
}
