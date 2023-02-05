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
    public GameObject cardManager;
    public GameManager gameManager;
    public GameObject audioEffect;
    public bool combatInProgress;
    private int resourceType;
    public GameObject resourceManager;
    public float resourceTimer;
    [SerializeField] int territoryType;
    private bool hasResources = true;

    public float currentSuccessRate = 0f;
    private void Awake()
    {
        switch(territoryType){
            case 0:
            baseTerritory = new EasyTerritory();
            baseTerritory.Initialize();
            hasResources = false;
            break;
            case 1:
            baseTerritory = new WaterTerritory();
            baseTerritory.Initialize();
            break;
            case 2:
            baseTerritory = new PotassiumTerritory();
            baseTerritory.Initialize();
            break;
            case 3:
            baseTerritory = new PhosphorusTerritory();
            baseTerritory.Initialize();
            break;
            case 4:
            baseTerritory = new MediumTerritory();
            baseTerritory.Initialize();
            hasResources = false;
            break;
            case 5:
            baseTerritory = new HardTerritory();
            baseTerritory.Initialize();
            hasResources = false;
            break;
            case 6:
            baseTerritory = new BossTerritory();
            baseTerritory.Initialize();
            hasResources = false;
            break;
        }
        // baseTerritory = new PotassiumTerritory();
        // baseTerritory.Initialize();
        resourceTimer = (float)baseTerritory.ResourceRate;
        slider.maxValue = baseTerritory.TimeToTake;
        territoryTaken = false;
        resourceType = baseTerritory.ResourceType;
        // resourceManager = GameObject.FindGameObjectWithTag("RM");
        audioEffect = GameObject.Find("Audio Effects");
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
        TakeTerritory(currentSuccessRate);
    }

    private void Update()
    {
        if(beingAttacked && slider.value < slider.maxValue){
            slider.value += Time.deltaTime;
        } else if (beingAttacked && slider.value >= slider.maxValue){
            slider.gameObject.SetActive(false);
            slider.value = 0f;
            EventResult();
        }
        if (territoryTaken && hasResources)
        {
            if (baseTerritory.ResourceTotal > 0)
            {
                resourceTimer -= Time.deltaTime;
                resourceManager.GetComponent<ResourceManager>().ResourceTimer(resourceType,resourceTimer);
                if (resourceTimer <= 0)
                {
                    baseTerritory.GenerateResource();
                    Debug.Log("saudando a mandioca "+ baseTerritory.ResourceTotal);
                    resourceManager.GetComponent<ResourceManager>().AddResource(resourceType,1);
                    resourceTimer = baseTerritory.ResourceRate;
                }
            }
        }
    }


    public float getSuccessRate(int damage){
        currentSuccessRate = baseTerritory.CheckSuccesRate(damage);
        return currentSuccessRate;
    }
    private void TakeTerritory(float successRate)
    {
        // int damage = character.GetComponent<BlankCardScript>().getCardAttack();
        
        // int random = Random.Range(0, 10);
        //character.GetComponent<CanvasGroup>().blocksRaycasts = true;
        bool hasWon = baseTerritory.Victory(successRate);
        Debug.Log(hasWon);
        if (hasWon)
        {
            this.GetComponent<Image>().color = Color.white;
            territory = true;
            territoryTaken = true;
            territoryManager.GetComponent<TerritoryManager>().Manager();
            audioEffect.GetComponent<AudioSource>().clip = audioEffect.GetComponent<AudioScript>().success;
            audioEffect.GetComponent<AudioSource>().Play();
        }
        else
        {
            this.GetComponent<Image>().color = Color.grey;
            territory = false;
            audioEffect.GetComponent<AudioSource>().clip = audioEffect.GetComponent<AudioScript>().failed;
            audioEffect.GetComponent<AudioSource>().Play();

        }
        //cards.Remove(character);
        ////character.GetComponent<CharacterScript>().Token.SetActive(false);
        //slotTokens[0].SetActive(false);
        cardManager.GetComponent<CardManager>().enableCards(cards);
        cards = new List<GameObject>();
        setTokens();
        beingAttacked = false;
        resetTokens();
        currentSuccessRate = 0f;
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
            slider.value = 0f;
            setTokens();
            // StartCoroutine(LoadAsynchronously());
            //TakeTerritory();
            return;
        }


        cardManager.GetComponent<CardManager>().enableCards(cards);
        cards = new List<GameObject>();
        //territory = false;
        //cards.Remove(character);
        //character.GetComponent<CanvasGroup>().blocksRaycasts = true;

        //character.GetComponent<CharacterScript>().Token.SetActive(false);
        //slotTokens[0].SetActive(false);
        //character.GetComponent<CharacterScript>().Card.SetActive(true);
        //character.GetComponent<RectTransform>().position = character.GetComponent<CharacterScript>().lastPosition;
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
            slotTokens[index].GetComponent<Image>().sprite = card.transform.GetChild(0).GetComponent<Image>().sprite;
            index++;
        }
    }

}
