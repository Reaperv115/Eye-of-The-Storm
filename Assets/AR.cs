

using UnityEngine;

public class AR : WeaponBase
{
    Ray ray;
    RaycastHit hit;

    [SerializeField]
    Transform barrel;

    public LayerMask layermask;
    // Start is called before the first frame update
    void Start()
    {
        ammo = 30f;
        maxAmmo = 190f;
        damage = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(barrel.transform.position, barrel.transform.forward * Mathf.Infinity, Color.blue);
        if (Input.GetMouseButtonDown(0))
        {
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
