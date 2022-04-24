using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWritterEffect : MonoBehaviour
{
    [SerializeField] private float typeWritterSpeed = 50f;
    
    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(Type(textToType, textLabel));
    }

    private IEnumerator Type(string textToType, TMP_Text textLabel)
    {
        float t = 0;
        int charIndex = 0;
        textLabel.text = string.Empty;

        while(charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeWritterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }

}
