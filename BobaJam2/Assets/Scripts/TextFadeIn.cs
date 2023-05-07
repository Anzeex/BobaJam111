using System.Collections;
using UnityEngine;
using TMPro;

public class TextFadeIn : MonoBehaviour
{
    public float fadeInTime = 1.0f;
    private TextMeshProUGUI[] textMeshObjects;

    private void Awake()
    {
        textMeshObjects = GetComponentsInChildren<TextMeshProUGUI>();

        // Set initial alpha to 0
        foreach (TextMeshProUGUI textMesh in textMeshObjects)
        {
            Color textColor = textMesh.color;
            textColor.a = 0;
            textMesh.color = textColor;
        }
    }

    private void Start()
    {
    }

    public IEnumerator FadeInText(float duration)
    {
        Debug.Log("fade in text");
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            foreach (TextMeshProUGUI textMesh in textMeshObjects)
            {
                Color textColor = textMesh.color;
                textColor.a = Mathf.Clamp01(elapsedTime / duration);
                textMesh.color = textColor;
            }

            yield return null;
        }
    }
}
