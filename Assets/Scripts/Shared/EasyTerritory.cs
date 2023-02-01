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


    public override void ManageResource()
    {
        // a cada RESOURCERATE segundos, reduz 1 do RESOURCETOTAL. Até chegar a 0
    }

    public override bool ResolveCombat(int damage)
    {
        int totalDamage = damage*timeToTake;
        if(totalDamage >= hitPoints) {
            return true;
        } else {
            float successRate = (totalDamage/hitPoints)*100;
            int random = Random.Range(0, 100);
            if(random <= successRate){
                return true;
            } else{
                return false;
            }
        }
    }
    
}