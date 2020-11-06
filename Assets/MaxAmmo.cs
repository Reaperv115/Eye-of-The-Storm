using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAmmo : PowerUpsBase
{
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
        base.Effect();
        for (int i = 0; i < player.GetComponent<Arsenal>().arsenal.Length; ++i)
        {
            if (player.GetComponent<Arsenal>().arsenal[i] == null)
            {
                break;
            }
            else
            {
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<EnergyHammer>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<EnergyHammer>().mag = player.GetComponent<Arsenal>().arsenal[i].GetComponent<EnergyHammer>().magCapacity;
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<EnergyHammer>().reserves = player.GetComponent<Arsenal>().arsenal[i].GetComponent<EnergyHammer>().reservesCapacity;
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<AR>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<AR>().mag = player.GetComponent<Arsenal>().arsenal[i].GetComponent<AR>().magCapacity;
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<AR>().reserves = player.GetComponent<Arsenal>().arsenal[i].GetComponent<AR>().reservesCapacity; ;
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<smg>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<smg>().mag = player.GetComponent<Arsenal>().arsenal[i].GetComponent<smg>().magCapacity;
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<smg>().reserves = player.GetComponent<Arsenal>().arsenal[i].GetComponent<smg>().reservesCapacity;
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<pistol>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<pistol>().mag = player.GetComponent<Arsenal>().arsenal[i].GetComponent<pistol>().magCapacity;
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<pistol>().reserves = player.GetComponent<Arsenal>().arsenal[i].GetComponent<pistol>().reservesCapacity;
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<shotgun>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<shotgun>().mag = player.GetComponent<Arsenal>().arsenal[i].GetComponent<shotgun>().magCapacity;
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<shotgun>().reserves = player.GetComponent<Arsenal>().arsenal[i].GetComponent<shotgun>().reservesCapacity;
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<GrenadeLauncher>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<GrenadeLauncher>().mag = player.GetComponent<Arsenal>().arsenal[i].GetComponent<GrenadeLauncher>().magCapacity;
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<GrenadeLauncher>().reserves = player.GetComponent<Arsenal>().arsenal[i].GetComponent<GrenadeLauncher>().reservesCapacity;
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<RocketLauncher>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<RocketLauncher>().mag = player.GetComponent<Arsenal>().arsenal[i].GetComponent<RocketLauncher>().magCapacity;
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<RocketLauncher>().reserves = player.GetComponent<Arsenal>().arsenal[i].GetComponent<RocketLauncher>().reservesCapacity;
                }
                if (player.GetComponent<Arsenal>().arsenal[i].GetComponent<SniperRifle>())
                {
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<SniperRifle>().mag = player.GetComponent<Arsenal>().arsenal[i].GetComponent<SniperRifle>().magCapacity;
                    player.GetComponent<Arsenal>().arsenal[i].GetComponent<SniperRifle>().reserves = player.GetComponent<Arsenal>().arsenal[i].GetComponent<SniperRifle>().reservesCapacity;
                }
            }


        }
    }
}
