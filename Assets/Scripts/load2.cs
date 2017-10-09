using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class load2 : MonoBehaviour {

    void nextLevel()
    {
        StartCoroutine("wait");
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(30f);
        SceneManager.LoadScene(4);
    }

    void Awake()
    {
        nextLevel();
    }
}
