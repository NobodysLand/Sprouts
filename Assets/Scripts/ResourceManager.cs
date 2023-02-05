using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [SerializeField]int water;
    [SerializeField]int potassium;
    [SerializeField]int phosphorus;
    [SerializeField]int nitrogen;

    [SerializeField] TextMeshProUGUI waterText;
    [SerializeField] TextMeshProUGUI potassiumText;
    [SerializeField] TextMeshProUGUI phosphorusText;
    [SerializeField] TextMeshProUGUI nitrogenText;
    // Start is called before the first frame update
    void Start()
    {
        water = 2;
        potassium = 1;
        phosphorus = 0;
        nitrogen = 0;
    }

    // Update is called once per frame
    void Update()
    {
        waterText.text = "WATER: "+water.ToString();
        potassiumText.text = "POTASSIUM: "+potassium.ToString();
        phosphorusText.text = "PHOSPHATE: "+phosphorus.ToString();
        // nitrogenText.text = nitrogen.ToString();
    }

    public void AddResource(int resource, int quantity){
        switch(resource){
            case 0:
            water+=quantity;
            break;
            case 2:
            phosphorus+=quantity;
            break;
            case 1:
            potassium+=quantity;
            break;
            case 3:
            nitrogen+=quantity;
            break;
        }
    }

    public void SubtractResource(int resource, int quantity){
        switch(resource){
            case 0:
            water-=quantity;
            break;
            case 2:
            phosphorus-=quantity;
            break;
            case 1:
            potassium-=quantity;
            break;
            case 3:
            nitrogen-=quantity;
            break;
        }
    }

    public int GetAvailableWater(){
        return water;
    }
    public int GetAvailablePotassium(){
        return potassium;
    }
    public int GetAvailablePhosphorus(){
        return phosphorus;
    }
}
