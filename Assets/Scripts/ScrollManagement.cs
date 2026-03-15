using System.Collections;
using TMPro;
using UnityEngine;

public class ScrollManagement: MonoBehaviour
{
    private TextMeshProUGUI scrollClickText;
    void Start()
    {
        scrollClickText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(textFlash(0.75f));
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
