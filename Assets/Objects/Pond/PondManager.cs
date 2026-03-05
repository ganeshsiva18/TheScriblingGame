using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PondManager: MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject pondRipple, fishingLine;
    [SerializeField] private InteractibleDefiner definer;
    [SerializeField] private List<GameObject> fishes;
    [SerializeField] private InventoryItem salmon;
    private List<char> fishCharacters = new(){'F', 'I', 'S', 'H', 'x'};

    readonly private Vector2 fishingLineSpawn = new Vector2(-10f, 24f);
    private GameObject fishingLineInstance;
    private float pondRippleTimer;

    private float fishTimer;
    private float fishHookedTimer;
    private bool isFishing;
    private bool fishHooked;
    private bool interactible;

    public bool getFishingState() { return isFishing; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interactible = definer.interactible;
        if (fishes.Count > 0) 
        {
            pondRippleTimer -= Time.deltaTime;
            if (pondRippleTimer <= 0)
            {
                pondRippleTimer = Random.Range(1f, 4f);
                SpawnRipple();
            }
            if (fishHooked)
            {
                SpawnFishHookedRipples();
                fishHookedTimer -= Time.deltaTime;
                if (fishHookedTimer < 0)
                {
                    fishHooked = false;
                    fishTimer = Random.Range(3f, 10f);
                }
            }
            if (isFishing)
            {
                fishTimer -= Time.deltaTime;
                if (fishTimer <= 0)
                {
                    fishHooked = true;
                    fishHookedTimer = Random.Range(1f, 2f);
                }
            }
        }
    }

    private void SpawnRipple()
    {
        Destroy(Instantiate(pondRipple, new Vector2(transform.position.x + Random.Range(-1.5f, 1.5f), transform.position.y + Random.Range(-.5f, .5f)), Quaternion.identity), .5f);
    }
    private void SpawnFishHookedRipples()
    {
        int randomNum = Random.Range(0, 10);
        if (randomNum == 0)
        {
            Destroy(Instantiate(pondRipple, new Vector2(transform.position.x + Random.Range(-.75f, .25f), transform.position.y + Random.Range(0f, -1f)), Quaternion.identity), .5f);
        }
    }
    private void CastLine()
    {
        isFishing = true;
        fishTimer = Random.Range(3f, 10f);
        fishingLineInstance = Instantiate(fishingLine, fishingLineSpawn, Quaternion.identity);
    }

    public void ReelLine()
    {
        isFishing = false;
        fishHooked = false;
        fishingLineInstance.GetComponentInChildren<Animator>().SetTrigger("stopFishing");
        Destroy(fishingLineInstance, .5f);
    }
    private void CatchFish()
    {
        ReelLine();
        if (fishes.Count > 0)
        { 
            int fishIndex = Random.Range(0, fishes.Count);
            if (fishIndex == fishes.Count-1 && fishCharacters[fishIndex] == 'x')
            {
                Destroy(fishes[fishIndex]);
                fishes.RemoveAt(fishIndex);
                fishCharacters.RemoveAt(fishIndex);
                InventoryManager.Instance.AddInventoryItem(salmon);
                GameManager.Instance.fishCollected = true;
            } 
            else
            {
                Destroy(fishes[fishIndex]);
                LetterManager.Instance.AddLetter(fishCharacters[fishIndex], new Vector2(transform.position.x + Random.Range(-.75f, .25f), transform.position.y + Random.Range(0f, -1f)));
                fishes.RemoveAt(fishIndex);
                fishCharacters.RemoveAt(fishIndex);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && interactible)
        {
            if (!isFishing)
            {
                CastLine();
            }
            else if (fishHooked)
            {
                CatchFish();
            } else
            {
                ReelLine();
            }
        }
    }
}


