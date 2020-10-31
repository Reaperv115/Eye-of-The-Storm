using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDamage : PowerUpsBase
{
    float damageMultiplier;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Effect()
    {
        for (int i = 0; i < player.GetComponent<Arsenal>().arsenal.Length; ++i)
        {
            if (player.GetComponent<Arsenal>().arsenal[i] == null)
            {
                break;
            }
            else
            {
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<AR>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<AR>().weaponDamage *= damageMultiplier;
                    Debug.Log("AR damage multiplied");
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<smg>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<smg>().weaponDamage *= damageMultiplier;
                    Debug.Log("smg damage multiplied");
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<pistol>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<pistol>().weaponDamage *= damageMultiplier;
                    Debug.Log("pistol damage multiplied");
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<shotgun>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<shotgun>().weaponDamage *= damageMultiplier;
                    Debug.Log("shotgun damage multiplied");
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<GrenadeLauncher>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<GrenadeLauncher>().weaponDamage *= damageMultiplier;
                    Debug.Log("grenadelauncher damage multiplied");
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<RocketLauncher>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<RocketLauncher>().weaponDamage *= damageMultiplier;
                    Debug.Log("rocket launcher damage multiplied");
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<SniperRifle>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<SniperRifle>().weaponDamage *= damageMultiplier;
                    Debug.Log("sniper rifle damage multiplied");
                }
            }
            

        }
    }
}
