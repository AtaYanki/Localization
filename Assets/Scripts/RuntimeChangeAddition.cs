using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuntimeChangeAddition : MonoBehaviour
{
    [SerializeField]private InputField inputField;
    [SerializeField]private Translator translator;

    public void ChangeChar()
    {
        translator.ChangeNewChar("{name}", inputField.text);
    }
}
