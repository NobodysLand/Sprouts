using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlankCardScript : MonoBehaviour
{

    [SerializeField] GameObject weakCardPrefab;
    [SerializeField] GameObject mediumCardPrefab;
    [SerializeField] GameObject strongCardPrefab;
    [SerializeField] GameObject opCardPrefab;
    [SerializeField] TextMeshProUGUI attackText;
    [SerializeField] TextMeshProUGUI defenseText;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] int test;

    BaseCard baseCard;
    // Start is called before the first frame update
    void Start()
    {
        switch(test){
            case 0:
            InstantiateWeak();
            break;
            case 1:
            InstantiateMedium();
            break;
            case 2:
            InstantiateStrong();
            break;
            case 3:
            InstantiateOP();
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateWeak() {
        GameObject prefab = Instantiate(weakCardPrefab,new Vector3(0,0,0), Quaternion.identity);
        prefab.transform.SetParent(this.gameObject.transform,false);
        baseCard = new WeakCard();
        baseCard.Initialize();
        setCardInitialTexts();
    }
    void InstantiateMedium() {
        GameObject prefab = Instantiate(mediumCardPrefab,new Vector3(0,0,0), Quaternion.identity);
        prefab.transform.SetParent(this.gameObject.transform,false);
        baseCard = new MediumCard();
        baseCard.Initialize();
        setCardInitialTexts();
    }
    void InstantiateStrong() {
        GameObject prefab = Instantiate(strongCardPrefab,new Vector3(0,0,0), Quaternion.identity);
        prefab.transform.SetParent(this.gameObject.transform,false);
        baseCard = new StrongCard();
        baseCard.Initialize();
        setCardInitialTexts();
    }
    void InstantiateOP() {
        GameObject prefab = Instantiate(opCardPrefab,new Vector3(0,0,0), Quaternion.identity);
        prefab.transform.SetParent(this.gameObject.transform,false);
        baseCard = new OPCard();
        baseCard.Initialize();
        setCardInitialTexts();
    }

    void setCardInitialTexts(){
        attackText = transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();
        defenseText = transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>();
        hpText = transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<TextMeshProUGUI>();
        attackText.text = "ATK: "+baseCard.Attack.ToString();
        defenseText.text = "DEF: "+baseCard.Defense.ToString();
        if(baseCard.HP <10){
            hpText.text = "0"+baseCard.HP.ToString();
        } else{
            hpText.text = baseCard.HP.ToString();
        }
    }
}
