using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    public ClothingItem[] clothingItems; // Reference to all ClothingItem objects in the scene

    void Start()
    {
        // Find all ClothingItem objects in the scene
        clothingItems = FindObjectsOfType<ClothingItem>();

        // Attach the Reset method to the button's onClick event
        GetComponent<Button>().onClick.AddListener(Reset);
    }

    // Reset method to reset changes made by ClothingItem objects
    void Reset()
    {
        foreach (ClothingItem item in clothingItems)
        {
            item.ResetState(); // Reset the state of the ClothingItem
        }
    }

}
