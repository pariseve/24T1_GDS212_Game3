using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    public GameObject[] panels; // Array to hold references to all panels

    private AudioManager audioManager;

    void Start()
    {
        // Attach the Reset method to the button's onClick event
        GetComponent<Button>().onClick.AddListener(Reset);

        GameObject audioManagerObject = GameObject.FindGameObjectWithTag("Audio");

        // Check if the AudioManager GameObject exists
        if (audioManagerObject != null)
        {
            // Get the AudioManager component attached to the GameObject
            audioManager = audioManagerObject.GetComponent<AudioManager>();
        }
        else
        {
            // Print a warning message if AudioManager GameObject is not found
            Debug.LogWarning("AudioManager GameObject not found in the scene.");
        }
    }

    // Reset method to reset changes made by ClothingItem objects
    void Reset()
    {
        // Reset clothing items in all panels
        foreach (GameObject panel in panels)
        {
            ClothingItem[] clothingItems = panel.GetComponentsInChildren<ClothingItem>(true);
            foreach (ClothingItem item in clothingItems)
            {
                item.ResetState(); // Reset the state of the ClothingItem
            }
        }
        if (audioManager != null)
        {
            audioManager.DropSFX(); // Make sure to call the method from the AudioManager
        }
        else
        {
            Debug.LogWarning("AudioManager reference is null.");
        }
    }
}
