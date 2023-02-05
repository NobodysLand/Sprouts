using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TokenScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject attackModal;
    // private bool clicked = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Color.white;
        attackModal.GetComponent<AttackModalScript>().removeToken(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Color.white;
    }

}
