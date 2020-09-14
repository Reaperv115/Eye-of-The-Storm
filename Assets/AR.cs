

using UnityEditor.SceneManagement;
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
        if (collider.transform.CompareTag("Player"))
        {
            for (int i = 0; i < GameObject.Find("Mystery Box").GetComponent<TheBox>().arsenal.Count;)
            {
                if (gameObject == GameObject.Find("Mystery Box").GetComponent<TheBox>().arsenal[i].gameObject)
                {
                    Debug.Log("added ammo");
                    ++ammo;
                    break;
                }
                else if (i == GameObject.Find("Mystery Box").GetComponent<TheBox>().arsenal.Count - 1 && gameObject != GameObject.Find("Mystery Box").GetComponent<TheBox>().arsenal[i])
                {
                    Debug.Log("Added gun to arsenal");
                    GameObject.Find("Mystery Box").GetComponent<TheBox>().arsenal.Add(gameObject);
                    collider.gameObject.transform.Find("Main Camera").GetComponent<MouseLook>().previousWeapon = collider.gameObject.transform.Find("Main Camera").GetComponent<MouseLook>().currentWeapon;
                    collider.gameObject.transform.Find("Main Camera").GetComponent<MouseLook>().currentWeapon = gameObject;
                }
                else
                {
                    ++i;
                }
            }
        }
    }
}
