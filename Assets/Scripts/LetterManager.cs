using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterManager: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI letterReferenceHeadText;
    [SerializeField] private GameObject letterObject;
    [SerializeField] private GameObject[] letterReferenceLetters;

    public List<char> lettersFound;
    public static LetterManager Instance;
    private readonly Dictionary<char, int> charNumPairs = new()
        {
            { 'A', 1 },
            { 'B', 2 },
            { 'C', 3 },
            { 'D', 4 },
            { 'E', 5 },
            { 'F', 6 },
            { 'G', 7 },
            { 'H', 8 },
            { 'I', 9 },
            { 'J', 10 },
            { 'K', 11 },
            { 'L', 12 },
            { 'M', 13 },
            { 'N', 14 },
            { 'O', 15 },
            { 'P', 16 },
            { 'Q', 17 },
            { 'R', 18 },
            { 'S', 19 },
            { 'T', 20 },
            { 'U', 21 },
            { 'V', 22 },
            { 'W', 23 },
            { 'X', 24 },
            { 'Y', 25 },
            { 'Z', 26 },
        };

    private void Awake()
    {
        Instance = this;
    }

    // Animate letter object
    public void LetterAnimate(Vector2 spawnPos, char letter)
    {
        Vector2 vel = new Vector2(Random.Range(-3f,3f), Random.Range(0, 5f));
        float rot = Random.Range(-45, 45);

        GameObject letterFall = Instantiate(letterObject, spawnPos, Quaternion.identity);
        Rigidbody2D rb = letterFall.GetComponent<Rigidbody2D>();

        rb.angularVelocity = rot;
        rb.linearVelocity = vel;
        letterFall.GetComponent<TextMeshPro>().text = letter.ToString();
        Destroy(letterFall, 5f);
    }

    // Add an array of letters
    public void AddLetters(char[] chars, Vector2 position)
    {
        SoundManager.Instance.PlaySound2D("chaching");
        for (int i = 0; i < chars.Length; i++) 
        {
            AddLetter(chars[i], position);
        }
    }

    // Add a single letter
    public void AddLetter(char letter, Vector2 letterSpawnPos)
    {
        if (!lettersFound.Contains(letter))
        {
            LetterAnimate(letterSpawnPos, letter);
            lettersFound.Add(letter);
            letterReferenceHeadText.text = lettersFound.Count.ToString();
            letterReferenceLetters[charNumPairs[letter] - 1].SetActive(true);
            GameEndCheck();
        }
    }

    // Check if all letters found
    private void GameEndCheck()
    {
        if (lettersFound.Count == 26)
        {
            GameManager.Instance.canSettings = false;
            GameManager.Instance.canMove = false;
            GameManager.Instance.playerScene = false;
            SceneManager.LoadSceneAsync(3);
        }
    }
}
