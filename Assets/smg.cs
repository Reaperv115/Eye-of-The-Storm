using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smg : WeaponBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
