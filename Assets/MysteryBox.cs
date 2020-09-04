using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapons;
    [SerializeField]
    Transform startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void giverandomWeapon()
    {
        int randomWeapon = Random.Range(0, weapons.Length);
        Vector3 scale = weapons[randomWeapon].transform.localScale;
        weapons[randomWeapon].transform.localScale /= 4;
        Instantiate(weapons[randomWeapon], startingPosition.position, startingPosition.rotation);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            giverandomWeapon();
        }
    }
}
