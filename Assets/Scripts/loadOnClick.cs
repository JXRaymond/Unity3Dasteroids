using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadOnClick : MonoBehaviour
{

    // Use this for initialization
    public void LoadScene(int level)
    {
        PlayerPrefs.SetInt("SpaceLives", 3);
        PlayerPrefs.SetInt("SpaceScore", 0);
        SceneManager.LoadScene(level);
    }
}
