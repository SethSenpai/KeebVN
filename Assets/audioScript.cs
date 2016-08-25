using UnityEngine;
using System.Collections;

public class audioScript : MonoBehaviour {

    public GameObject textReader;
    private textReader readScript;
    private AudioSource asc;

    // Use this for initialization
    void Start () {
        readScript = textReader.GetComponent<textReader>();
        asc = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	    switch(readScript.bgMusic)
        {
            case "golden_week":
                Debug.Log("loading music and shit");
                AudioClip music = Resources.Load<AudioClip>("Audio/music/" + readScript.bgMusic);
                asc.clip = music;
                asc.Play();
                readScript.bgMusic = " ";

                break;

            case "#":
                asc.Stop();
                break;
        }
	}
}
