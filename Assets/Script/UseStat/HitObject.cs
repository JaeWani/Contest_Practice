using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : StatObejct
{
    protected void Hit(float Damage)
    {
        HP -= Damage;
    }
}
