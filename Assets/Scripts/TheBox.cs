using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBox : MonoBehaviour
{
    [SerializeField]
    List<GameObject> boxWeapons;
    [SerializeField]
    Transform startingPosition;

    public GameObject randomweapon;
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
        if (other.transform.CompareTag("Player"))
        {
            int randomweaponIndex = Random.Range(0, boxWeapons.Count);
            boxWeapons[randomweaponIndex].SetActive(true);
            randomweapon = Instantiate(boxWeapons[randomweaponIndex], startingPosition.position, startingPosition.rotation);
        }
    }
}
