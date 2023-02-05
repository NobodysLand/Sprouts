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
    [SerializeField]float waterTimer;
    [SerializeField]float potassiumTimer;
    [SerializeField]float phosphorusTimer;
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
        waterText.text = "WATER: "+water.ToString()+"("+(int)waterTimer+"s)";
        potassiumText.text = "POTASSIUM: "+potassium.ToString()+"("+(int)potassiumTimer+"s)";
        phosphorusText.text = "PHOSPHATE: "+phosphorus.ToString()+"("+(int)phosphorusTimer+"s)";
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
    public void ResourceTimer(int resource, float timer){
        switch(resource){
            case 0:
            waterTimer=timer;
            break;
            case 2:
            phosphorusTimer=timer;
            break;
            case 1:
            potassiumTimer=timer;
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
