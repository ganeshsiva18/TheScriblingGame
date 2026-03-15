using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker: MonoBehaviour
{
    private Light2D fire;
    private float timeFlicker;
    private float flickerIntensity;
    private float flickerRadius;
    void Start()
    {
        fire = GetComponent<Light2D>();
        StartCoroutine(fireFlicker());
    }

    private IEnumerator fireFlicker()
    {
        while (true)
        {
            timeFlicker = Random.Range(0f, 0.1f);
            flickerIntensity = Random.Range(0.2f, 0.3f);
            flickerRadius = Random.Range(2f, 2.5f);
            yield return new WaitForSeconds(timeFlicker);

            fire.intensity = flickerIntensity;
            fire.pointLightInnerRadius = flickerRadius;
        }
    }
}
