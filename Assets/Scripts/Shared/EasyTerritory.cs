    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EasyTerritory : BaseTerritory
{
    public override void Initialize()
    {
        name = "fácil";
        flavorText = "polenta";
        resourceType = ResouceType.Water;
        resourceTotal = 20;
        resourceRate = 10;
        hitPoints = 60;
        timeToTake = 15;
    }


    public override void GenerateResource()
    {
        resourceTotal--;
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