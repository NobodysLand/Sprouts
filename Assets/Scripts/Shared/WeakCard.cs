using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
class WeakCard : BaseCard
{
    public override void Initialize()
    {
        int[] _cost = {2,0,0,0};
        cost = _cost;
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
    public override int Defense
    {
        get
        {
            return defense;
        }
    }
    public override int Attack
    {
        get
        {
            return attack;
        }
    }
    public override int[] Cost
    {
        get
        {
            return cost;
        }
    }
}