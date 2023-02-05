using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
class OPCard : BaseCard
{
    public override void Initialize()
    {
        int[] _cost = {8,0,2,1};
        cost = _cost;
        attack = 20;
        defense = 10;
        hitPoints = 25;
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