using System.Collections;
using TMPro;
using UnityEngine;

public class ScrollManagement: MonoBehaviour
{
    private TextMeshProUGUI scrollClickText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scrollClickText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(textFlash(0.75f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator textFlash(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            scrollClickText.alpha = 0;
            yield return new WaitForSeconds(time);
            scrollClickText.alpha = 1;
        }
    }
}
