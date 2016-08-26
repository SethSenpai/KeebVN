using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonScript : MonoBehaviour {

    public GameObject popupwindow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void mainMenu()
    {
        popupwindow.SetActive(true);
    }

    public void mainMenuYes()
    {
        SceneManager.LoadScene(0);
    }

    public void mainMenuNo()
    {
        popupwindow.SetActive(false);
    }
}
