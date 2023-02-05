using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private List<GameObject> territories;
    private GameObject modalDefend;

    private void Awake()
    {
        territories = GameObject.Find("TerritoryManager").GetComponent<TerritoryManager>().territories;
        modalDefend = GameObject.Find("TerritoryManager");
    }

    public void enemyAttack()
    {
        GameObject territoryAttack = null;
        foreach(GameObject territory in territories)
        {
            Territory t = territory.GetComponent<Territory>();
            if (t.territoryTaken)
            {
                territoryAttack = territory;
                break;
            }
        }

        if (territoryAttack != null)
        {
            modalDefend.SetActive(true);
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
