using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class load1 : MonoBehaviour
{

    void nextLevel()
    {
        StartCoroutine("wait");
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(60f);
        SceneManager.LoadScene(3);
    }

    void Awake()
    {
        nextLevel();
    }
}
