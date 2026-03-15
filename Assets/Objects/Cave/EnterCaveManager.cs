using UnityEngine;

public class EnterCaveManager: MonoBehaviour
{
    [SerializeField] private Animator exteriorCaveAnimator;
    [SerializeField] private Animator interiorCaveAnimator;
    [SerializeField] private Animator worldLightAnimator;
    [SerializeField] private Animator localLightAnimator;
    [SerializeField] private GameObject caveInterior;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnterCave();
    }

    private void EnterCave()
    {
        exteriorCaveAnimator.SetTrigger("EnterCave");
        worldLightAnimator.SetTrigger("Dim");
        localLightAnimator.SetTrigger("Brighten");
    }

    public void CaveTransition()
    {
        caveInterior.SetActive(true);
        interiorCaveAnimator.SetTrigger("InteriorFadeIn");
        gameObject.SetActive(false);
    }
}
