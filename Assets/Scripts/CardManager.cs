using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> cardsPosition = new List<GameObject>();
    public GameObject defaultCard;

    public void newCard()
    {
        if (cards.Count > 4)
            return;

        GameObject newCard = Instantiate(defaultCard);
        newCard.transform.SetParent(GameObject.Find("UI").transform);
        newCard.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newCard.GetComponent<RectTransform>().position = getPosition();
        cards.Add(newCard);
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
