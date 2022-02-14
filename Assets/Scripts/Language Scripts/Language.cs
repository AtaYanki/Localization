using System;
using System.Collections.Generic;
using UnityEngine;

namespace Language_Scripts
{
	public class Language : MonoBehaviour
	{
		private static Dictionary<string, string> Fields;
		private const string DefaultLang = "en";

		private void Awake()
		{
			LoadLanguage();
		}

		public static void LoadLanguage()//Adds the default language only the first time, constantly loads the language you left after the first boot
		{
			Fields ??= new Dictionary<string, string>();
		
			Fields.Clear();

			var lang = PlayerPrefs.GetString("_language", DefaultLang);

			if(PlayerPrefs.GetInt("_language_index", -1) == -1)
			{
				PlayerPrefs.SetInt("_language_index", 0);
			}

			var allTexts = (Resources.Load (@"Languages/" + lang) as TextAsset)?.text; //without (.txt)

			var lines = allTexts?.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

			if (lines == null) return;
			foreach (var line in lines)
			{
				if (line.IndexOf("=", StringComparison.Ordinal) < 0 || line.StartsWith("#")) continue;
				var key = line.Substring(0, line.IndexOf("=", StringComparison.Ordinal));
				var value = line.Substring(line.IndexOf("=", StringComparison.Ordinal) + 1,
					line.Length - line.IndexOf("=", StringComparison.Ordinal) - 1).Replace("\\n", Environment.NewLine);
				Fields.Add(key, value);
			}
		}

		public static string GetTraduction(string key)//Gets the translation of the key
		{
			if (Fields.ContainsKey(key)) return Fields[key];
			Debug.LogError("There is no key with name: [" + key + "] in your text files");
			return null;
		}
	}
}