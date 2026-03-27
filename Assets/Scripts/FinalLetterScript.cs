using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class FinalLetterScript : MonoBehaviour
{
    private float textTimer = 0;
    private float voiceTimer = 0;
    private readonly float textLimit = 0.05f;
    private readonly string text = "Dear XXX,\\r\\n\\r\\nHey! I hope the money in this envelope serves you well!";
    private int i = 0;
    private bool doText = false;
    [SerializeField] TextMeshPro textfield;

    // Update is called once per frame
    void Update()
    {
        if (doText)
        {
            textTimer += Time.deltaTime;
            voiceTimer += Time.deltaTime;
            if (textLimit < textTimer)
            {
                textTimer = 0;
                if (voiceTimer > textLimit * 3)
                {
                    SoundManager.Instance.PlaySound2D("deepvoice");
                    voiceTimer = 0;
                }

                textfield.text += text[i];
                i++;
                if (i == text.Length)
                {
                    i = 0;
                    doText = false;
                }
            }
        }
    }

    public void StartText()
    {
        doText = true;
    }
}
