using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    protected override void Used(){
        base.Used();
        if(Player.instance.BulletLV < 5)
            Player.instance.BulletLV++;
        else 
            GameManager.instance.Score += 1000;

        Destroy(gameObject);
    }
}
