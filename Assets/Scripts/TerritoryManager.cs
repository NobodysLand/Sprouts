using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerritoryManager : MonoBehaviour
{
    public List<GameObject> territories = new List<GameObject>();

    private void Awake()
    {
        Manager();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Manager()
    {
        foreach(GameObject t in territories)
        {
            EnableTerritory(t);
        } 
    }

    private void EnableTerritory(GameObject territory)
    {
        bool enable = false;
        foreach (GameObject t in territory.GetComponent<Territory>().requiredTerritory)
        {
            if (t.GetComponent<Territory>().territoryTaken)
            {
                enable = true;
                break;
            }
        }

        if (enable || territory.GetComponent<Territory>().requiredTerritory.Count == 0)
        {
            territory.GetComponent<Image>().raycastTarget = true;
            if (territory.GetComponent<Territory>().territoryTaken)
            {
                territory.GetComponent<Image>().color = Color.white;
            }
            else
            {
                territory.GetComponent<Image>().color = Color.grey;
            }

        }
        else
        {
            territory.GetComponent<Image>().raycastTarget = false;
            territory.GetComponent<Image>().color = Color.black;
        }

    }

}
