using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DummyAI: MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private GameObject pow;
    [SerializeField] private Animator animator;
    [SerializeField] private TabiGameAI tabiGameAI;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.tabiFinished) 
        {
            if (timer <= 0f && !tabiGameAI.isTabiGame)
            {
                Punch(false);
                timer = Random.Range(0.75f, 3f);
            }
            timer -= Time.deltaTime;
        }
    }

    public void Punch(bool playerPunch)
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (!playerPunch)
        { 
            mousePos = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
        }
        Destroy(Instantiate(pow, mousePos, Quaternion.identity), 1f);
        animator.SetTrigger("dummyHit");
        SoundManager.Instance.PlaySoundPositional("punch", mousePos, 1, 20);
        if (!GameManager.Instance.dummyHit && playerPunch)
        {
            GameManager.Instance.dummyHit = true;
            char[] charArray = { 'P', 'O', 'W' };
            LetterManager.Instance.AddLetters(charArray, mousePos);
        }
    }
}
