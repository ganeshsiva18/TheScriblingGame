using System.Collections;
using UnityEngine;

public class TabiGameController: MonoBehaviour
{
    private GameObject player;
    private float timer;
    private float limit;
    private int threatsDestroyed = 0;
    public int threatThreshold = 20;

    private GameObject tabiGuy;
    private TabiGameAI tabiGameAI;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject threat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tabiGuy = GameObject.FindGameObjectWithTag("Tabi Guy");
        tabiGameAI = tabiGuy.GetComponent<TabiGameAI>();
        tabiGameAI.instructionsClosed = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameScreen.transform.position = player.transform.position;
        if (threatsDestroyed >= threatThreshold)
        {
            tabiGameAI.WinTabiGame();
        }
        if (tabiGameAI.instructionsClosed) { 
            timer += Time.deltaTime;
            if (timer > limit)
            {
                timer = 0;
                if (threatsDestroyed < 5)
                {
                    limit = Random.Range(1.75f, 2.75f);
                }
                else if (threatsDestroyed < 10)
                {
                    limit = Random.Range(1.5f, 2.5f);
                }
                else if (threatsDestroyed < 15)
                {
                    limit = Random.Range(1f, 1.8f);
                }
                else
                {
                    limit = Random.Range(0.75f, 1.5f);
                }
                SpawnThreat();
            }
        }
    }

    public void DestroyThreat(GameObject gm) // Destroys threat without harming player
    {
        threatsDestroyed++;
        Destroy(gm);
    }

    public void SelfDestructThreat() // Blows Up threat to harm player
    {
        tabiGameAI.health--;
        if (tabiGameAI.health <= 0)
        {
            tabiGameAI.ExitTabiGame();
        }
    }

    private void SpawnThreat() // Spawns threat in Tabi Minigame
    {
        Instantiate(threat, new Vector2(Random.Range(-3, 3) + player.transform.position.x, Random.Range(-1.5f, 1.5f) + player.transform.position.y), Quaternion.identity);
    }
}
