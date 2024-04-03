using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRFootsteps : MonoBehaviour
{
  public AudioSource audioSource; // Reference to the AudioSource component
  public AudioClip[] footsteps; // Array of AudioClip objects holding your footstep sound effects
  public float minPitch = 0.9f; // Minimum pitch variation
  public float maxPitch = 1.1f; // Maximum pitch variation

  private int lastPlayedIndex = -1; // Stores index of the last played footstep clip
  private Vector3 lastPosition; // Stores the character's position from the previous frame
  private bool isMoving = false;
  private float moveTimer = 0.0f; // Timer to control footstep frequency
  private float footstepInterval = 0.3f; // Minimum time between footsteps (adjustable)

  void Start()
  {
    audioSource = GetComponent<AudioSource>(); // Get AudioSource component
    lastPosition = transform.position; // Get initial position
  }

  void Update()
  {
    // Check for movement based on position change
    isMoving = Vector3.Distance(transform.position, lastPosition) > 0.01f; // Adjust threshold as needed

    // Handle footstep playback based on movement and timer
    if (isMoving)
    {
      moveTimer += Time.deltaTime;
      if (moveTimer >= footstepInterval)
      {
        PlayRandomFootstep();
        moveTimer = 0.0f;
      }
    }

    // Update lastPosition for next frame comparison
    lastPosition = transform.position;
  }

  void PlayRandomFootstep()
  {
    if (footsteps.Length > 0)
    {
      int randomIndex;
      do
      {
        randomIndex = Random.Range(0, footsteps.Length); // Get random index
      } while (randomIndex == lastPlayedIndex); // Ensure it's not the same as the last clip

      lastPlayedIndex = randomIndex; // Update last played index

      // Apply random pitch variation
      audioSource.pitch = Random.Range(minPitch, maxPitch);
      audioSource.clip = footsteps[randomIndex]; // Set random footstep clip
      audioSource.Play(); // Play the chosen footstep sound
    }
  }
}
