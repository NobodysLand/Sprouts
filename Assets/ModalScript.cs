using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ModalScript : MonoBehaviour, IDropHandler
{
    public TMP_Text title;
    public TMP_Text text;
    public Image image;
    public List<GameObject> cardsSlot;

    public void setCards()
    {
        int index = 0;
        foreach (GameObject card in cardsSlot)
        {
            GameObject newCard = Instantiate(card.transform.Find("Card").gameObject);
            newCard.SetActive(true);
            newCard.transform.position = transform.Find("CardsSlot").GetChild(index).transform.position;
            newCard.GetComponent<RectTransform>().localScale = transform.Find("CardsSlot").GetChild(index).GetComponent<RectTransform>().localScale;
            newCard.transform.SetAsLastSibling();
            newCard.transform.SetParent(transform.Find("CardsSlot").GetChild(index).transform);
            index++;
        }

    }

    public void OnDrop(PointerEventData eventdata)
    {
        cardsSlot.Add(eventdata.pointerDrag);
        eventdata.pointerDrag.SetActive(false);
        setCards();
    }


    }
