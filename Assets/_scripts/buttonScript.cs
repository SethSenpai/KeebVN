using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonScript : MonoBehaviour {

    public GameObject popupwindow;
    public GameObject UI;
    public textReader trX;

    public bool superspeed = false;
    private bool interfaceBool = true;

	// Use this for initialization
	void Start () {
       // UI = GameObject.Find("canvas");
	}
	
	// Update is called once per frame
	void Update () {
        checkHideInterfacePress();
        checkSuperSpeedPress();
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

    void checkHideInterfacePress()
    {
        string keyLoad = PlayerPrefs.GetString("hideInterfaceKey");
        keyLoad = keyLoad.ToLower();

        if (Input.GetKeyDown(keyLoad))
        {
            if (interfaceBool)
            {
                interfaceBool = false;
                UI.SetActive(false);
            }
            else
            {
                interfaceBool = true;
                UI.SetActive(true);
            }
        }
    }

    void checkSuperSpeedPress()
    {
        string keyLoad = PlayerPrefs.GetString("skipKey");
        keyLoad = keyLoad.ToLower();
        keyLoad = "left shift";

        if (Input.GetKeyDown(keyLoad))
        {
            if (superspeed != true)
            {
                superspeed = true;
                
            }

        }

        if (Input.GetKeyUp(keyLoad))
        {
            if (superspeed)
            {
                superspeed = false;
                
            }
        }

    }
}
