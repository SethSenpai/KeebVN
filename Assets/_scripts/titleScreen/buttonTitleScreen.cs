using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonTitleScreen : MonoBehaviour {

    public GameObject container;
    public GameObject sld;
    public GameObject sldA;

	// Use this for initialization
	void Start () {
        sld = GameObject.Find("SliderText");
        sldA = GameObject.Find("SliderAudioMaster");

        Slider tempSlide = sld.GetComponent<Slider>();
        Slider tempSlideA = sldA.GetComponent<Slider>();

        Text tempText = sld.GetComponentInChildren<Text>();
        Text tempTextA = sldA.GetComponentInChildren<Text>();

        float slideVal = Mathf.Round((PlayerPrefs.GetFloat("txtSpeed") * -100 + 8.1f) * 10f) / 10f;

        tempTextA.text = "Master Audio: " + PlayerPrefs.GetFloat("audioMaster") * 10;
        tempText.text = "Text Speed: " + slideVal;

        tempSlideA.value = PlayerPrefs.GetFloat("audioMaster");
        tempSlide.value = PlayerPrefs.GetFloat("txtSpeed");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void closeGame()
    {
        Application.Quit();
    }

    public void newGame()
    {
        SceneManager.LoadScene(1);
    }

    public void settings()
    {
        iTween.MoveTo(container, iTween.Hash("position", new Vector3(container.transform.position.x, 4.95f, container.transform.position.z), "easeType", "easeInOutQuint", "speed", 10));
    }

    public void back()
    {
        iTween.MoveTo(container, iTween.Hash("position", new Vector3(container.transform.position.x, -4.95f, container.transform.position.z), "easeType", "easeInOutQuint", "speed", 10));
        PlayerPrefs.Save();
    }

    public void sliderTextMove()
    {
        Slider tempSlide = sld.GetComponent<Slider>();
        Text tempText = sld.GetComponentInChildren<Text>();
        float slideVal = Mathf.Round((tempSlide.value * -100 + 8.1f)*10f)/10f;
        tempText.text = "Text Speed: " + slideVal;
        PlayerPrefs.SetFloat("txtSpeed", tempSlide.value);

    }

}
