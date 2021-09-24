using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguage : MonoBehaviour
{
	public static event Translation Translate;
	public delegate void Translation();

	public Translator[] list;

	[SerializeField]private Dropdown dropdown;

    public string[] myLangs;
	private int index;

	private void Awake()
	{
		dropdown = this.GetComponent <Dropdown> ();
		int v = PlayerPrefs.GetInt ("_language_index", 0);
		dropdown.value = v;

		dropdown.onValueChanged.AddListener (delegate {
			index = dropdown.value;
			PlayerPrefs.SetInt ("_language_index", index);
			PlayerPrefs.SetString ("_language", myLangs [index]);
			Language.LoadLanguage();
			ApplyLanguageChanges ();
		});
	}

	void ApplyLanguageChanges()
	{
		Translate();
	}
}