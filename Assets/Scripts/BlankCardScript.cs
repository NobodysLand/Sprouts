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
        if(test == 0) {
            // InstantiateWeak();
        }
        // switch(test){
        //     case 0:
        //     InstantiateWeak();
        //     break;
        //     case 1:
        //     InstantiateMedium();
        //     break;
        //     case 2:
        //     InstantiateStrong();
        //     break;
        //     case 3:
        //     InstantiateOP();
        //     break;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject InstantiateWeak() {
        GameObject prefab = Instantiate(weakCardPrefab,new Vector3(0,0,0), Quaternion.identity);
        // prefab.transform.SetParent(this.gameObject.transform,false);
        baseCard = new WeakCard();
        baseCard.Initialize();
        // setCardInitialTexts(prefab);
        return prefab;
    }
    public GameObject InstantiateMedium() {
        GameObject prefab = Instantiate(mediumCardPrefab,new Vector3(0,0,0), Quaternion.identity);
        prefab.transform.SetParent(this.gameObject.transform,false);
        baseCard = new MediumCard();
        baseCard.Initialize();
        // setCardInitialTexts(prefab);
        return prefab;
    }
    public GameObject InstantiateStrong() {
        GameObject prefab = Instantiate(strongCardPrefab,new Vector3(0,0,0), Quaternion.identity);
        prefab.transform.SetParent(this.gameObject.transform,false);
        baseCard = new StrongCard();
        baseCard.Initialize();
        // setCardInitialTexts(prefab);
        return prefab;
    }
    public GameObject InstantiateOP() {
        GameObject prefab = Instantiate(opCardPrefab,new Vector3(0,0,0), Quaternion.identity);
        prefab.transform.SetParent(this.gameObject.transform,false);
        baseCard = new OPCard();
        baseCard.Initialize();
        // setCardInitialTexts(prefab);
        return prefab;
    }

    public void setCardInitialTexts(GameObject prefab, int type){
        switch(type){
            case 0:
            baseCard = new WeakCard();
        baseCard.Initialize();
            break;
            case 1:
            baseCard = new MediumCard();
        baseCard.Initialize();
            break;
            case 2:
            baseCard = new StrongCard();
        baseCard.Initialize();
            break;
            case 3:
            baseCard = new OPCard();
        baseCard.Initialize();
            break;
        }
        attackText = prefab.transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();
        defenseText = prefab.transform.GetChild(0).GetChild(0).GetChild(4).GetComponent<TextMeshProUGUI>();
        hpText = prefab.transform.GetChild(0).GetChild(0).GetChild(5).GetComponent<TextMeshProUGUI>();
        attackText.text = "ATK: "+baseCard.Attack.ToString();
        defenseText.text = "DEF: "+baseCard.Defense.ToString();
        if(baseCard.HP <10){
            hpText.text = "0"+baseCard.HP.ToString();
        } else{
            hpText.text = baseCard.HP.ToString();
        }
    }
}
