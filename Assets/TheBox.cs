using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBox : MonoBehaviour
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            int randomweaponIndex = Random.Range(0, weapons.Length);
            Instantiate(weapons[randomweaponIndex], startingPosition.position, startingPosition.rotation);
        }
    }
}
