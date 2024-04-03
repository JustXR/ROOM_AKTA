using System.Collections;
using UnityEngine;

public class DelayedAudioSource : MonoBehaviour
{
  public float delayTime = 13.0f; // Time in seconds before playing the audio

  private AudioSource audioSource;

  void Start()
  {
    audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    StartCoroutine(PlayAudioDelayed());
  }

  IEnumerator PlayAudioDelayed()
  {
    yield return new WaitForSeconds(delayTime); // Wait for the specified delay
    audioSource.Play(); // Play the audio clip
  }
}
