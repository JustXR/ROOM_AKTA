using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private bool sceneChangeTriggered = false;
    private float timeInScene = 0f;
    public float sceneChangeTime = 30f; // Set the time in seconds before scene change

    void Update()
    {
        // Check if the player is in the scene for 30 seconds
        if (!sceneChangeTriggered)
        {
            timeInScene += Time.deltaTime;
            if (timeInScene >= sceneChangeTime)
            {
                Debug.Log("Changing scene due to time limit.");
                // Change the scene
                ChangeScene();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player hits the collider
        if (other.CompareTag("Player") && !sceneChangeTriggered)
        {
            Debug.Log("Changing scene due to collider hit.");
            // Change the scene
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        // Set scene change triggered to prevent multiple scene changes
        sceneChangeTriggered = true;
        // Load the next scene, you can specify the scene name or build index
        SceneManager.LoadScene("SampleScene");
    }
}
