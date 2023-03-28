using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    protected override void Used(){
        if(Player.BulletLV < 5)
        Player.BulletLV++;

        Debug.Log("PowerUp");

        Destroy(gameObject);
    }

}
