using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] TextMeshPro text;
    public void ActivateButton()
    {
        button.SetActive(true);
        text.text = "";
    }
    public void QuitOut()
    {
        Debug.Log("Quitting game...");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
