using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AttackModalScript : MonoBehaviour, IDropHandler
{
    public TMP_Text title;
    public TMP_Text text;
    public Image image;
    public List<GameObject> cardsSlot;
    public List<GameObject> tokensSlot;
    public GameObject territory;
    public GameManager gameManager;

    public void setCards()
    {
        int index = 0;
        foreach (GameObject card in cardsSlot)
        {
            tokensSlot[index].SetActive(true);
            tokensSlot[index].GetComponent<Image>().sprite = card.GetComponent<Image>().sprite;
            index++;
        }

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
        tokensSlot[0].SetActive(false);
        tokensSlot[1].SetActive(false);
        tokensSlot[2].SetActive(false);
    }

}
