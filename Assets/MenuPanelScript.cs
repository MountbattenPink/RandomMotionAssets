using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets;
using UnityEngine.Events;

public class MenuPanelScript : MonoBehaviour {
	[SerializeField] public InputField High;
	[SerializeField] public InputField Width;
	[SerializeField] public Text ErrorMessage;
	[SerializeField] public Button BuildButton;
	int WidthCubes = 0;
	int HightCubes = 0;
	public static string errorText = "Invalid input: only positive numeric values,\nmin. possible value = 1,\nmax. possible value = 50";
	// Use this for initialization
	void Start () {
		ErrorMessage.text = "";
		High.onEndEdit.AddListener(
			delegate{
				HighInput(High);
			});
		Width.onEndEdit.AddListener (delegate{
			WidthInput(Width);
		});
		BuildButton.onClick.AddListener (delegate{
			Submit();
		});
	}
	void TextEdited(){
	}

	// Update is called once per frame
	void Update () {
	}

	public int ValidateInput(InputField field){
		int n=0;
		if (!(int.TryParse (field.text, out n) && n > 0 && n < 100)) {
			Debug.Log ("Invalid input");
			ErrorMessage.text = errorText;
		}
		return n;
	}

	public void HighInput(InputField HighField){
		ValidateInput(HighField);
	}

	public void WidthInput(InputField WidthField){
		ValidateInput(WidthField);
	}

	public void Submit(){
		ErrorMessage.text = "";
		HightCubes = ValidateInput (High);
		WidthCubes = ValidateInput (Width);
		if (!ErrorMessage.text.Equals (errorText)) {
			Debug.Log("WIN");
			CubeGenerator.generateCubes (WidthCubes,HightCubes);
		}
	}
}
