using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translator : MonoBehaviour
{
	public List<TranslationAddition> additions;

	[Tooltip ("enter one of the keys that you specify in your (txt) file for all languages.\n\n# for example: [HOME=home]\n# the key here is [HOME]")]
	public string key;
	
	public string ChangeKey
	{
		get { return key; }
		set 
		{
			key = value;
			Translate();
		}
	}

	public void ChangeNewChar(string _oldChar, string _newChar)
	{
		for (int i = 0; i < additions.Count; i++)
		{
			if(additions[i].oldChar == _oldChar)
			{
				additions[i].ChangeNewChar(_newChar);
			}
		}
		Translate();
	}

	public delegate void Translation();

	private void Start()
	{
		Translate();
	}

	private void OnEnable()
	{
		ChangeLanguage.Translate += Translate;
	}

	private void OnDisable()
	{
		ChangeLanguage.Translate -= Translate;
	}

	public void Translate()
	{
		if(additions.Count != 0)
		{
			string tempText = Language.GetTraduction(key);
			for (int i = 0; i < additions.Count; i++)
			{
				tempText = tempText.Replace(additions[i].oldChar, additions[i].newChar);
			}
			GetComponent<Text>().text = tempText;
		}else GetComponent<Text>().text = Language.GetTraduction(key);
	}
}
[System.Serializable]
public class TranslationAddition
{
    public string oldChar;
    public string newChar;

    public TranslationAddition()
    {
        oldChar = "";
        newChar = "";
    }

	public void ChangeNewChar(string _newChar)
	{
		newChar = _newChar;
	}
}