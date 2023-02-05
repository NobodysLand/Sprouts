using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CardManager : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> cardsPosition = new List<GameObject>();
    public GameObject recruitModal;
    public GameObject weakCard;
    public GameObject mediumCard;
    public GameObject strongCard;
    public GameObject opCard;
    public GameObject weakIcon;
    public GameObject mediumIcon;
    public GameObject strongIcon;
    public GameObject opIcon;
    public GameObject resourceManager;
    public int availableWater;
    public int availablePotassium;
    public int availablePhosphorus;
    public int[] weakCost;
    public int[] mediumCost;
    public int[] strongCost;
    public int[] opCost;
    public GameObject ui;
    [SerializeField] TextMeshProUGUI[] weakCostsText;
    [SerializeField] TextMeshProUGUI[] mediumCostsText;
    [SerializeField] TextMeshProUGUI[] strongCostsText;
    [SerializeField] TextMeshProUGUI[] opCostsText;

    public void newCard(int i)
    {
        if (cards.Count > 4)
            return;
        GameObject newCard = new GameObject();
        if (i == 0 && isCraftable(weakCost))
        {
            newCard = Instantiate(weakCard);
            SubtractResource(weakCost);
        }
        if (i == 1 && isCraftable(mediumCost))
        {
            newCard = Instantiate(mediumCard);
            SubtractResource(mediumCost);
        }
        if (i == 2 && isCraftable(strongCost))
        {
            newCard = Instantiate(strongCard);
            SubtractResource(strongCost);
        }
        if (i == 3 && isCraftable(opCost))
        {
            newCard = Instantiate(opCard);
            SubtractResource(opCost);
        }
        if(newCard.GetComponents<Component>().Length ==1 )
        {
            Destroy(newCard);
            return;
        }
        newCard.transform.SetParent(GameObject.Find("UI").transform);
        newCard.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newCard.GetComponent<RectTransform>().position = getPosition();
        ui.GetComponent<BlankCardScript>().setCardInitialTexts(newCard,i);
        cards.Add(newCard);
    }

    private void Start() {
        BaseCard _baseCard;
        _baseCard = new WeakCard();
        _baseCard.Initialize();
        weakCost = _baseCard.Cost;
        _baseCard = new MediumCard();
        _baseCard.Initialize();
        mediumCost = _baseCard.Cost;
        _baseCard = new StrongCard();
        _baseCard.Initialize();
        strongCost = _baseCard.Cost;
        _baseCard = new OPCard();
        _baseCard.Initialize();
        opCost = _baseCard.Cost;
        SetCostText(weakCostsText,weakCost);
        SetCostText(mediumCostsText,mediumCost);
        SetCostText(strongCostsText,strongCost);
        SetCostText(opCostsText,opCost);
    }

    private void Update() {
        availableWater = resourceManager.GetComponent<ResourceManager>().GetAvailableWater();
        availablePotassium = resourceManager.GetComponent<ResourceManager>().GetAvailablePotassium();
        availablePhosphorus = resourceManager.GetComponent<ResourceManager>().GetAvailablePhosphorus();
        if(!isCraftable(weakCost)){
            weakIcon.GetComponent<Image>().color = Color.grey;
        } else {
            weakIcon.GetComponent<Image>().color = Color.white;
        }
        if(!isCraftable(mediumCost)){
            mediumIcon.GetComponent<Image>().color = Color.grey;
        } else {
            mediumIcon.GetComponent<Image>().color = Color.white;
        }
        if(!isCraftable(strongCost)){
            strongIcon.GetComponent<Image>().color = Color.grey;
        } else {
            strongIcon.GetComponent<Image>().color = Color.white;
        }
        if(!isCraftable(opCost)){
            opIcon.GetComponent<Image>().color = Color.grey;
        } else {
            opIcon.GetComponent<Image>().color = Color.white;
        }
    }

    void SubtractResource(int[] cardCost){
        resourceManager.GetComponent<ResourceManager>().SubtractResource(0,cardCost[0]);
        resourceManager.GetComponent<ResourceManager>().SubtractResource(1,cardCost[1]);
        resourceManager.GetComponent<ResourceManager>().SubtractResource(2,cardCost[2]);
    }

    public Vector3 getPosition()
    {
        GameObject cardSlot = new GameObject();
        foreach (GameObject card in cardsPosition)
        {
            if (!card.activeSelf)
            {
                card.SetActive(true);
                cardSlot = card;
                break;
            }
        }
        Debug.Log(cardSlot);
        return cardSlot.GetComponent<RectTransform>().position;
    }


    public void enableCards(List<GameObject> cards)
    {
        foreach (GameObject card in cards)
        {
            backToHand(card);
        }
        cards = new List<GameObject>();
    }

    public void backToHand(GameObject card)
    {
        card.GetComponent<CanvasGroup>().blocksRaycasts = true;
        card.GetComponent<CanvasGroup>().alpha = 1f;
        card.SetActive(true);
        card.GetComponent<RectTransform>().position = card.GetComponent<CharacterScript>().lastPosition;
    }

    public void openModal()
    {
        recruitModal.SetActive(true);
    }

    public void closeModal()
    {
        recruitModal.SetActive(false);
    }

    public int WaterCost(int[] totalCost){
        return totalCost[0];
    }
    public int PotassiumCost(int[] totalCost){
        return totalCost[1];
    }
    public int PhosphorusCost(int[] totalCost){
        return totalCost[2];
    }

    public bool isCraftable(int[] totalCost){
        // Debug.Log(totalCost);
        return (WaterCost(totalCost) <= availableWater && PotassiumCost(totalCost) <= availablePotassium && PhosphorusCost(totalCost) <= availablePhosphorus);
    }

    void SetCostText(TextMeshProUGUI[] cardCostText, int[] totalCost){
        cardCostText[0].text = WaterCost(totalCost).ToString();
        cardCostText[1].text = PotassiumCost(totalCost).ToString();
        cardCostText[2].text = PhosphorusCost(totalCost).ToString();
    }
}
