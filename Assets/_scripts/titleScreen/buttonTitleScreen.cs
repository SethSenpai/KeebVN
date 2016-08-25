using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonTitleScreen : MonoBehaviour {

    public GameObject container;

	// Use this for initialization
	void Start () {
	
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
        iTween.MoveTo(container, iTween.Hash("y", 222.64, "easeType", "easeInOutQuint", "speed", 10));
    }

    public void back()
    {
        iTween.MoveTo(container, iTween.Hash("y", -62.32, "easeType", "easeInOutQuint", "speed", 10));
    }
}
