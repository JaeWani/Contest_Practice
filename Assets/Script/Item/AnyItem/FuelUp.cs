using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelUp : Item
{
    protected override void Used(){
        base.Used();
        Player.instance.Fuel += 25;
        Destroy(gameObject);
    }
}
