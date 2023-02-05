    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WaterTerritory : BaseTerritory
{
    public override void Initialize()
    {
        name = "fácil";
        flavorText = "polenta";
        resourceType = ResouceType.Water;
        resourceTotal = 20;
        resourceRate = 10;
        hitPoints = 4;
        timeToTake = 5;
    }


    public override void GenerateResource()
    {
        resourceTotal--;
    }

public override float TimeToTake
    {
        get
        {
            return timeToTake;
        }
    }
    public override float CheckSuccesRate(int damage)
    {
        float totalDamage = damage;
        if(totalDamage >= hitPoints) {
            return 100f;
        } else {
            return (totalDamage/hitPoints)*100;
        }
    }

    public override bool Victory(float successRate){
        int random = Random.Range(0, 100);
            if(random <= successRate){
                return true;
            } else{
                return false;
            }
    }
    public override int ResourceRate
    {
        get
        {
            return resourceRate;
        }
    }

    public override int ResourceTotal
    {
        get
        {
            return resourceTotal;
        }
    }

    public override int ResourceType
    {
        get
        {
            return (int) resourceType;
        }
    }
    
}