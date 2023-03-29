using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurabilityUp : Item
{
    protected override void Used(){
        base.Used();
        Player.instance.HP += 10;
        Destroy(gameObject);
    }
}
