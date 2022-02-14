using System.Collections.Generic;
using Language_Scripts;
using UnityEngine;

//This is test script for text change in runtime.The important place is line 20.
public class RuntimeChangeText : MonoBehaviour
{
    [SerializeField]private List<string> texts = new List<string>();
    [SerializeField]private Translator translator;
    private int textCount = 1;

    public void ChangeText()
    {
        translator.ChangeKey = texts[textCount];
        textCount++;
        if(textCount >= texts.Count)
        {
            textCount = 0;
        }
    }
}