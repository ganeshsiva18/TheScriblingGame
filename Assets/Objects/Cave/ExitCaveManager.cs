using System;
using UnityEngine;

public class ExitCaveManager: MonoBehaviour
{
    [SerializeField] private Animator exteriorCaveAnimator;
    [SerializeField] private Animator interiorCaveAnimator;
    [SerializeField] private Animator worldLightAnimator;
    [SerializeField] private Animator localLightAnimator;
    [SerializeField] private GameObject caveExterior;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ExitCave();
    }

    private void ExitCave()
    {
        caveExterior.SetActive(true);
        exteriorCaveAnimator.SetTrigger("ExitCave");
        interiorCaveAnimator.SetTrigger("InteriorFadeOut");
        worldLightAnimator.SetTrigger("Brighten");
        localLightAnimator.SetTrigger("Dim");
        gameObject.SetActive(false);
    }
}
