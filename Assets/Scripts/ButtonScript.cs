using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Sprite defaultButton;
    public Sprite defaultHoverButton;
    public Sprite alternativeButton;
    public Sprite alternativeHoverButton;

    private bool clicked = false;

    public void Awake()
    {
        if (alternativeButton == null)
        {
            alternativeButton = defaultButton;
            alternativeHoverButton = defaultHoverButton;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clicked)
        {
            this.GetComponent<Image>().sprite = defaultButton;
            clicked = false;
            return;
        }
        this.GetComponent<Image>().sprite = alternativeButton;
        clicked = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (clicked)
        {
            this.GetComponent<Image>().sprite = alternativeHoverButton;
            return;
        }
        this.GetComponent<Image>().sprite = defaultHoverButton;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (clicked)
        {
            this.GetComponent<Image>().sprite = alternativeButton;
            return;
        }
        this.GetComponent<Image>().sprite = defaultButton;
    }
}
