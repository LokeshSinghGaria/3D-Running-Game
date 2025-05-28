using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;    // Player GameObject with PlayerMovement script
    [SerializeField] GameObject playerAnim;  // Player GameObject with Animator component

    void OnTriggerEnter(Collider other)
    {
        // Check if thePlayer and playerAnim are assigned
        if (thePlayer != null && playerAnim != null)
        {
            // Disable PlayerMovement script
            PlayerMovement movement = thePlayer.GetComponent<PlayerMovement>();
            if (movement != null)
            {
                movement.enabled = false;
                Debug.Log("PlayerMovement script disabled.");
            }
            else
            {
                Debug.LogError("PlayerMovement component not found on thePlayer.");
            }

            // Play animation
            Animator animator = playerAnim.GetComponent<Animator>();
            if (animator != null)
            {
                animator.Play("Stumble Backwards");
                Debug.Log("Stumble Backwards animation played.");
            }
            else
            {
                Debug.LogError("Animator component not found on playerAnim.");
            }
        }
        else
        {
            Debug.LogError("thePlayer or playerAnim is not assigned in the Inspector.");
        }
    }
}
