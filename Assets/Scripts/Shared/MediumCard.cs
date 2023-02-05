using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
class MediumCard : BaseCard
{
    public override void Initialize()
    {
        int[] _cost = {4,2,0,0};
        cost = _cost;
        attack = 9;
        defense = 3;
        hitPoints = 10;
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

    public override int Attack
    {
        get
        {
            return attack;
        }
    }
    public override int Defense
    {
        get
        {
            return defense;
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