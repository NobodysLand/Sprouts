using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [SerializeField]int water;
    [SerializeField]int potassium;
    [SerializeField]int phosporus;
    [SerializeField]int nitrogen;

    [SerializeField] TextMeshProUGUI waterText;
    [SerializeField] TextMeshProUGUI potassiumText;
    [SerializeField] TextMeshProUGUI phosporusText;
    [SerializeField] TextMeshProUGUI nitrogenText;
    // Start is called before the first frame update
    void Start()
    {
        water = 0;
        potassium = 0;
        phosporus = 0;
        nitrogen = 0;
    }

    // Update is called once per frame
    void Update()
    {
        waterText.text = water.ToString();
        potassiumText.text = potassium.ToString();
        phosporusText.text = phosporus.ToString();
        // nitrogenText.text = nitrogen.ToString();
    }

    public void AddResource(int resource, int quantity){
        switch(resource){
            case 0:
            water+=quantity;
            break;
            case 2:
            phosporus+=quantity;
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
            phosporus-=quantity;
            break;
            case 1:
            potassium-=quantity;
            break;
            case 3:
            nitrogen-=quantity;
            break;
        }
    }
}
