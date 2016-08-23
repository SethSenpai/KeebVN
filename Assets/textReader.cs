﻿using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class textReader : MonoBehaviour
{
	private const float WAIT_TIME = 0.03f;

	public GameObject textbox;
	public GameObject backgroundContainer;
	//public int bgNr;
	Text text;

	public TextAsset loadFile;
    public GameObject characterPrefab;

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

    void addCharacter(string objName, string bodySprite, string facialExpression, string xPos, string yPos, string xStart, string yStart, string speed)
    {
        Vector3 Opos = new Vector3(float.Parse(xStart), float.Parse(yStart), 0);
        Vector3 Npos = new Vector3(float.Parse(xPos), float.Parse(yPos), 0);
        GameObject charTemp = Instantiate(characterPrefab);
        charTemp.name = "#" + objName;
        charTemp.transform.position = Opos;
        iTween.MoveTo(charTemp, Npos, float.Parse(speed));
      

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
				//Debug.Log(clickNr);
				textPart = wholeSlide[clickNr].Split(">"[0]);
                string tempCode = textPart[0];
                tempCode = tempCode.Remove(0, 1);
                codePart = tempCode.Split(","[0]);
                Debug.Log(codePart[0] + " & " + codePart[1]);
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
        //wholeText = Regex.Replace(wholeText, @"\u000A", "");
        wholeText = wholeText.Replace("\u000A", System.String.Empty);
        Debug.Log(wholeText);
        wholeSlide = wholeText.Split ("|"[0]);
		textPart = wholeSlide[clickNr].Split(">"[0]);
        //Debug.Log(textPart[1]);
        string tempCode = textPart[0];
        tempCode = tempCode.Remove(0, 1);
        codePart = tempCode.Split(","[0]);
		readCode();
	}

	void readCode(){
        for (int i=0; i < codePart.Length; i++){
            //change background bg:<backgroundnumber>
			if(codePart[i].StartsWith("bg:")){
				string[] codeValue;
				codeValue = codePart[i].Split(":"[0]);
				changeBG(codeValue[1]);
				Debug.Log("bg:" + codeValue[1]);
			}
            //add character to scene addChar:<objName>:<bodySprite>:<facialExpresion>:<xPos>:<yPos>:<xStart>:<yStart>
			if(codePart[i].StartsWith("addChar:")){
				string[] codeValue;
				codeValue = codePart[i].Split(":"[0]);
                addCharacter(codeValue[1], codeValue[2], codeValue[3], codeValue[4], codeValue[5], codeValue[6], codeValue[7], codeValue[8]);
				Debug.Log("addChar:" + codeValue[1]);
			}
			if(codePart[i].StartsWith("li:")){
				string[] codeValue;
				codeValue = codePart[i].Split(":"[0]);
				Debug.Log("li:" + codeValue[1]);
			}
		}
	}

}