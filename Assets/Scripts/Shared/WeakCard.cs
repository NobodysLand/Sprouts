using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
class WeakCard : BaseCard
{
    public override void Initialize()
    {
        attack = 4;
        defense = 1;
        hitPoints = 5;
    }

    public override int TakeDamage(int damage)
    {
        hitPoints -= damage;
        return hitPoints;
    }

    public override int HP
    {
        get
        {
            return hitPoints;
        }
    }
}