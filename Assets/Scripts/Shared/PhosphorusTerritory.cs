    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PhosphorusTerritory : BaseTerritory
{
    public override void Initialize()
    {
        name = "fácil";
        flavorText = "polenta";
        resourceType = ResouceType.Phosphorus;
        resourceTotal = 6;
        resourceRate = 25;
        hitPoints = 60;
        timeToTake = 30;
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
    public override bool ResolveCombat(int damage)
    {
        float totalDamage = damage*timeToTake;
        if(totalDamage >= hitPoints) {
            Debug.Log("favela venceu");
            return true;
        } else {
            float successRate = (totalDamage/hitPoints)*100;
            int random = Random.Range(0, 100);
            Debug.Log(successRate);
            Debug.Log(random);
            if(random <= successRate){
                Debug.Log("favela venceu");
                return true;
            } else{
                Debug.Log("Tururu");
                return false;
            }
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