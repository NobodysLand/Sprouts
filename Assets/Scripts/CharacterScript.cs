using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Vector3 lastPosition;
    public bool slotPlace = false;
    public GameObject slot;
    public GameObject lastSlot;
    public GameObject Card;
    public GameObject Token;
    public Slider slider;
    public GameManager gameManager;

    private BaseCard baseCard;

    public string teste;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        lastPosition = GetComponent<RectTransform>().position;
        this.transform.SetAsLastSibling();
        // baseCard = new WeakCard();
        // baseCard.Initialize();
    }

    public void OnBeginDrag(PointerEventData eventdata)
    {
        gameManager.dragging = true;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        slotPlace = false;
        transform.SetAsLastSibling();
        lastPosition = GetComponent<RectTransform>().position;
        if (slot)
        {
            lastSlot = slot;
        }
        slot = null;
    }
    public void OnEndDrag(PointerEventData eventdata)
    {
        gameManager.dragging = false;
        canvasGroup.alpha = 1f;
        if (!slot)
        {
            //if (lastSlot)
            //{
            //    lastSlot.GetComponent<Territory>().cards.Remove(this.gameObject);
            //}
            canvasGroup.blocksRaycasts = true;
            this.GetComponent<RectTransform>().position = lastPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameManager.dragging = true;
        GetComponent<Canvas>().sortingOrder = 6;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameManager.dragging = true;
        GetComponent<Canvas>().sortingOrder = 6;
        this.GetComponent<RectTransform>().localScale = this.GetComponent<RectTransform>().localScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameManager.dragging = false;
        GetComponent<Canvas>().sortingOrder = 5;
        this.GetComponent<RectTransform>().localScale = this.GetComponent<RectTransform>().localScale / 1.2f;

    }

    public void InitializeCard(int cardType){
        switch(cardType){
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
            teste="aqui";
            baseCard.Initialize();
            break;
            case 3:
            baseCard = new OPCard();
            baseCard.Initialize();
            break;
        }
    }

    public int getCardAttack(){
        return baseCard.Attack;
    }

}
