﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePoints : PowerUpsBase
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
        player.GetComponent<PlayerScore>().pointsperKill = 2;
        Debug.Log("points per kill: " + player.GetComponent<PlayerScore>().pointsperKill);
    }
}
