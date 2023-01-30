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

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        lastPosition = GetComponent<RectTransform>().position;
        this.transform.SetAsLastSibling();
    }

    public void OnBeginDrag(PointerEventData eventdata)
    {
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
        Debug.Log("ENDDRAG");
        canvasGroup.alpha = 1f;
        if (!slot)
        {
            if (lastSlot)
            {
                lastSlot.GetComponent<Territory>().cards.Remove(this.gameObject);
            }
            canvasGroup.blocksRaycasts = true;
            this.GetComponent<RectTransform>().position = lastPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = this.GetComponent<RectTransform>().localScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = this.GetComponent<RectTransform>().localScale / 1.2f;

    }

}
