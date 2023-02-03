using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Territory : MonoBehaviour, IDropHandler
{

    public Slider slider;
    GameObject character;
    public bool territory = false;
    public List<GameObject> cards = new List<GameObject>();
    public GameObject attackModal;

    public bool territoryTaken;
    public bool beingAttacked;
    private BaseTerritory baseTerritory;
    public List<GameObject> slotTokens;
    public List<GameObject> requiredTerritory;
    public GameObject territoryManager;
    public GameManager gameManager;

    public float resourceTimer;
    private void Awake()
    {
        baseTerritory = new EasyTerritory();
        baseTerritory.Initialize();
        resourceTimer = (float)baseTerritory.ResourceRate;
        territoryTaken = false;
    }
    public void OnDrop(PointerEventData eventdata)
    {
        gameManager.dragging = false;
        if (territoryTaken == false && beingAttacked == false)
        {
            character = eventdata.pointerDrag;

            character.GetComponent<RectTransform>().position = this.transform.GetChild(0).GetComponent<RectTransform>().position;
            character.GetComponent<CharacterScript>().slot = this.gameObject;
            cards.Add(character);
            character.GetComponent<CanvasGroup>().blocksRaycasts = false;
            //character.GetComponent<CharacterScript>().Token.SetActive(true);
            //slotTokens[0].SetActive(true);
            character.SetActive(false);

            character.GetComponent<CharacterScript>().slot = this.gameObject;
            //slider = character.GetComponent<CharacterScript>().slider;
            //StartCoroutine(LoadAsynchronously());
            character.transform.SetAsFirstSibling();
            attackModal.GetComponent<AttackModalScript>().cardsSlot = cards;
            attackModal.GetComponent<AttackModalScript>().territory = this.gameObject;
            attackModal.GetComponent<AttackModalScript>().setCards();
            gameManager.GetComponent<GameManager>().pauseGame(); //Time.timeScale = 0;
            attackModal.SetActive(true);


        }

    }

    IEnumerator LoadAsynchronously()
    {
        this.GetComponent<Image>().color = Color.red;
        slider.gameObject.SetActive(true);
        slider.value = 0f;
        float timer = 0.1f;
        while (timer < 0.9f)
        {
            timer += 0.1f;
            float progress = Mathf.Clamp01(timer / .9f);
            slider.value = progress;
            yield return new WaitForSeconds(1);
        }
        slider.gameObject.SetActive(false);
        EventResult();
    }

    private void EventResult()
    {
        TakeTerritory();
    }

    private void Update()
    {
        if (territoryTaken)
        {
            if (baseTerritory.ResourceTotal > 0)
            {
                resourceTimer -= Time.deltaTime;
                if (resourceTimer <= 0)
                {
                    baseTerritory.GenerateResource();
                    Debug.Log("saudando a mandioca " + baseTerritory.ResourceTotal);
                    resourceTimer = baseTerritory.ResourceRate;
                }
            }
        }
    }

    private void TakeTerritory()
    {
        int damage = character.GetComponent<CharacterScript>().getCardAttack();
        baseTerritory.ResolveCombat(damage);
        int random = Random.Range(0, 10);
        //character.GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (random > 4)
        {
            this.GetComponent<Image>().color = Color.white;
            territory = true;
            territoryTaken = true;
            territoryManager.GetComponent<TerritoryManager>().Manager();
        }
        else
        {
            this.GetComponent<Image>().color = Color.grey;
            territory = false;
        }
        //cards.Remove(character);
        ////character.GetComponent<CharacterScript>().Token.SetActive(false);
        //slotTokens[0].SetActive(false);
        enableCards();
        setTokens();
        beingAttacked = false;
        resetTokens();
        //character.GetComponent<CharacterScript>().Card.SetActive(true);
        //character.GetComponent<RectTransform>().position = character.GetComponent<CharacterScript>().lastPosition;


    }

    public void AttackModalEvent(bool choice)
    {
        attackModal.GetComponent<AttackModalScript>().territory = new GameObject();
        gameManager.GetComponent<GameManager>().pauseGame();//Time.timeScale = 1;
        attackModal.SetActive(false);

        if (choice)
        {
            beingAttacked = true;
            slider.gameObject.SetActive(true);
            setTokens();
            StartCoroutine(LoadAsynchronously());
            //TakeTerritory();
            return;
        }


        enableCards();
        //territory = false;
        //cards.Remove(character);
        //character.GetComponent<CanvasGroup>().blocksRaycasts = true;

        //character.GetComponent<CharacterScript>().Token.SetActive(false);
        //slotTokens[0].SetActive(false);
        //character.GetComponent<CharacterScript>().Card.SetActive(true);
        //character.GetComponent<RectTransform>().position = character.GetComponent<CharacterScript>().lastPosition;
    }

    private void enableCards()
    {
        Debug.Log(cards.Count);

        foreach (GameObject card in cards)
        {
            card.GetComponent<CanvasGroup>().blocksRaycasts = true;
            card.GetComponent<CanvasGroup>().alpha = 1f;
            card.SetActive(true);
            card.GetComponent<RectTransform>().position = card.GetComponent<CharacterScript>().lastPosition;
        }
        cards = new List<GameObject>();
    }

    private void resetTokens()
    {
        slotTokens[0].SetActive(false);
        slotTokens[1].SetActive(false);
        slotTokens[2].SetActive(false);
    }
    private void setTokens()
    {
        int index = 0;
        foreach (GameObject card in cards)
        {
            slotTokens[index].SetActive(true);
            slotTokens[index].GetComponent<Image>().sprite = card.GetComponent<Image>().sprite;
            index++;
        }
    }

}
