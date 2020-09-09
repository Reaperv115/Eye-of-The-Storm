

using UnityEngine;

public class AR : WeaponBase
{
    Ray ray;
    RaycastHit hit;

    [SerializeField]
    Transform barrel;

    public LayerMask layermask;
    GameObject currentWeapon;
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
        //Debug.DrawRay(barrel.transform.position, barrel.transform.forward * Mathf.Infinity, Color.blue);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    ray = new Ray(barrel.position, barrel.forward);
        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
        //    {
        //        Debug.Log(hit.transform.name);
        //        if (hit.transform.name.Contains("o"))
        //        {
        //            hit.transform.gameObject.GetComponent<FireEnemy>().takeDamage(damage);
        //            Debug.Log("enemy hit");
        //        }
        //    }
        //}
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.transform.tag);
        if (collider.transform.tag == "Player")
        {
            transform.parent = collider.transform.Find("Main Camera").GetComponent<MouseLook>().hand;
            transform.position = collider.transform.Find("Main Camera").GetComponent<MouseLook>().hand.position;
            transform.rotation = collider.transform.Find("Main Camera").GetComponent<MouseLook>().hand.rotation;
        }
    }
}
