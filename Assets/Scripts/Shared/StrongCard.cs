using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
class StrongCard : BaseCard
{
    public override void Initialize()
    {
        int[] _cost = {4,2,2,0};
        cost = _cost;
        attack = 13;
        defense = 5;
        hitPoints = 12;
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