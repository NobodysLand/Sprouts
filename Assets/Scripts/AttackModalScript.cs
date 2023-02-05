using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class AttackModalScript : MonoBehaviour, IDropHandler
{
    public TMP_Text title;
    public TMP_Text text;
    public TMP_Text successRateText;
    public Image image;
    public List<GameObject> cardsSlot;
    public List<GameObject> tokensSlot;
    public GameObject territory;
    public GameManager gameManager;
    public GameObject attackButton;
    public GameObject cardManager;
    public int totalAttack;
    public float currentSuccessRate = 0f;


    public void setCards()
    {
        resetTokens();
        enableButton();
        int index = 0;
        foreach (GameObject card in cardsSlot)
        {
            tokensSlot[index].SetActive(true);
            tokensSlot[index].GetComponent<Image>().sprite = card.transform.GetChild(0).GetComponent<Image>().sprite;
            index++;
            totalAttack+=card.GetComponent<CharacterScript>().getCardAttack();
        }

    }

    private void Update() {
        successRateText.text = "Win Rate: "+territory.GetComponent<Territory>().getSuccessRate(totalAttack)+"%";
    }

    public void OnDrop(PointerEventData eventdata)
    {
        gameManager.dragging = false;
        if (cardsSlot.Count > 2)
        {
            return;
        }
        cardsSlot.Add(eventdata.pointerDrag);
        territory.GetComponent<Territory>().cards = cardsSlot;
        eventdata.pointerDrag.SetActive(false);
        setCards();
    }

    public void attackAction(bool choice)
    {
        territory.GetComponent<Territory>().AttackModalEvent(choice);
        cardsSlot = new List<GameObject>();
        resetTokens();
    }

    private void resetTokens()
    {
        totalAttack = 0;
        tokensSlot[0].SetActive(false);
        tokensSlot[1].SetActive(false);
        tokensSlot[2].SetActive(false);
    }

    public void removeToken(GameObject token)
    {
        // Debug.Log(token.name);
        GameObject card = new GameObject();
        if (token.name == "Slot 1")
        {
            tokensSlot[0].SetActive(false);
            card = cardsSlot.ElementAt(0);
            cardsSlot.RemoveAt(0);
        }
        if (token.name == "Slot 2")
        {
            tokensSlot[1].SetActive(false);
            card = cardsSlot.ElementAt(1);

            cardsSlot.RemoveAt(1);
        }
        if (token.name == "Slot 3")
        {
            tokensSlot[2].SetActive(false);
            card = cardsSlot.ElementAt(2);

            cardsSlot.RemoveAt(2);
        }
        territory.GetComponent<Territory>().cards = cardsSlot;
        setCards();
        cardManager.GetComponent<CardManager>().backToHand(card);
        // totalAttack-=card.GetComponent<CharacterScript>().getCardAttack();
        Debug.Log(card.GetComponent<CharacterScript>().getCardAttack());
    }

    public void enableButton()
    {
        if(cardsSlot.Count == 0)
        {
            attackButton.GetComponent<Button>().enabled = false;
        }
        else
        {
            attackButton.GetComponent<Button>().enabled = true;
        }
    }

}
