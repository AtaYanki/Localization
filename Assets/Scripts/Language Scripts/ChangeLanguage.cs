using UnityEngine;
using UnityEngine.UI;

namespace Language_Scripts
{
	public class ChangeLanguage : MonoBehaviour
	{
		public static event Translation Translate;
		public delegate void Translation();

		[SerializeField]private Dropdown dropdown;

		public string[] languages;
		private int index;

		private void Awake()
		{
			dropdown = this.GetComponent <Dropdown> ();
			var v = PlayerPrefs.GetInt ("_language_index", 0);
			dropdown.value = v;

			dropdown.onValueChanged.AddListener (delegate {
				index = dropdown.value;
				PlayerPrefs.SetInt ("_language_index", index);
				PlayerPrefs.SetString ("_language", languages [index]);
				Language.LoadLanguage();
				ApplyLanguageChanges ();
			});
		}

		private static void ApplyLanguageChanges()
		{
			Translate?.Invoke();
		}
	}
}