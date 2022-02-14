using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Language_Scripts
{
	public class Translator : MonoBehaviour
	{
		public List<TranslationAddition> additions;

		[Tooltip ("enter one of the keys that you specify in your (txt) file for all languages.\n\n# for example: [HOME=home]\n# the key here is [HOME]")]
		public string key;
	
		public string ChangeKey
		{
			get => key;
			set 
			{
				key = value;
				Translate();
			}
		}

		public void ChangeNewChar(string oldChar, string newChar)
		{
			foreach (var addition in additions.Where(addition => addition.oldChar == oldChar))
			{
				addition.ChangeNewChar(newChar);
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

		private void Translate()
		{
			if(additions.Count != 0)
			{
				var tempText = Language.GetTraduction(key);
				tempText = additions.Aggregate(tempText, (current, addition) => current.Replace(addition.oldChar, addition.newChar));
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

		public void ChangeNewChar(string newChar)
		{
			this.newChar = newChar;
		}
	}
}