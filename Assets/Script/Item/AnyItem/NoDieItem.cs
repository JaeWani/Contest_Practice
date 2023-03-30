using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDieItem : Item
{
    protected override void Used(){
        base.Used();
        Player.instance.NoDieTime += 5;
        Destroy(gameObject);
    }
}
