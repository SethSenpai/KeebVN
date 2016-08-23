using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textReader : MonoBehaviour
{
	private const float WAIT_TIME = 0.03f;

	public GameObject textbox;
	public GameObject backgroundContainer;
	//public int bgNr;
	Text text;

	public TextAsset loadFile;

	private float waitTimer = 0.0f;
	private string wholeText = " ";
	private string[] wholeSlide;
	private string[] textPart;
	private string[] codePart;
	private string typewriterText = "";
	private int currentIndex = 0;
	private int clickNr = 0;

	void Start(){

		text = textbox.GetComponent<Text>();
		splitCodeStart();


	}

	void Update ()
	{
		typeWrite(); 
	}
	
	void OnGUI()
	{
		text.text = typewriterText;
	}

	void changeBG(string bgNumber)
	{	
		Sprite newBG = Resources.Load<Sprite> ("Backgrounds/Placeholder/" + bgNumber);
		SpriteRenderer bg = backgroundContainer.gameObject.GetComponent<SpriteRenderer>();
		bg.sprite = newBG; 
	}

	void typeWrite()
	{
		waitTimer += Time.deltaTime;

		//Debug.Log (currentIndex);

		if(Input.GetMouseButtonUp(0)){
			if (currentIndex == textPart[1].Length && clickNr < wholeSlide.Length-1){
				text.text = " ";
				typewriterText = "" ;
				clickNr ++;
				currentIndex = 0;
				Debug.Log(clickNr);
				textPart = wholeSlide[clickNr].Split("*"[0]);
				codePart = textPart[0].Split(","[0]);
				readCode();
				//Debug.Log(textPart[1]);
			}
			else{
				currentIndex = textPart[1].Length;
				typewriterText = textPart[1];
			}
		}
		
		if (waitTimer > WAIT_TIME && currentIndex < textPart[1].Length)
		{            
			typewriterText += textPart[1][currentIndex];
			waitTimer = 0.0f;
			++currentIndex;
		}   
	}

	void splitCodeStart()
	{
		wholeText = loadFile.text;
		wholeSlide = wholeText.Split ("|"[0]);
		textPart = wholeSlide[clickNr].Split("*"[0]);
		codePart = textPart[0].Split(","[0]);
		readCode();
	}

	void readCode(){
		for(int i=0; i < codePart.Length; i++){
			if(codePart[i].StartsWith("bg:")){
				string[] codeValue;
				codeValue = codePart[i].Split(":"[0]);
				changeBG(codeValue[1]);
				Debug.Log("bg:" + codeValue[1]);
			}
			if(codePart[i].StartsWith("ba:")){
				string[] codeValue;
				codeValue = codePart[i].Split(":"[0]);
				Debug.Log("ba:" + codeValue[1]);
			}
			if(codePart[i].StartsWith("li:")){
				string[] codeValue;
				codeValue = codePart[i].Split(":"[0]);
				Debug.Log("li:" + codeValue[1]);
			}
		}
	}

}