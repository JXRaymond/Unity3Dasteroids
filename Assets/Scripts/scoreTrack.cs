using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class scoreTrack : MonoBehaviour {
    GameObject userName;
	// Use this for initialization
	void Start () {

    }
	
	void Awake()
    {
        userName = GameObject.Find("InputField");
        userName.SetActive(false);
        PlayerPrefs.SetInt("New Score Flag", 0);
    }

    void Update()
    {
        if (scoreManager.getScore() > PlayerPrefs.GetInt("HiScore10"))
        {
            PlayerPrefs.SetInt("New Score Flag", 1);
            userName.SetActive(true);
            if (Input.GetKey("enter") || Input.GetKeyDown("return"))
            {
                scoreManager.saveScores(userName.GetComponent<UnityEngine.UI.InputField>().text);
                SceneManager.LoadScene("highscores");
            }
        }
        else
        {
            PlayerPrefs.SetInt("New Score Flag", 0);
            SceneManager.LoadScene("highscores");
        }
    }
}
