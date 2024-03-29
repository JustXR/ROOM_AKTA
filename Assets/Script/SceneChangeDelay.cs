using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeDelay : MonoBehaviour
{
    private float delayTime = 30f; // Delay time in seconds

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeSceneAfterDelay(delayTime));
    }

    // Coroutine to change the scene after a delay
    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SampleScene");
    }
}
