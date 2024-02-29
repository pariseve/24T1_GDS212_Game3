using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    public GameObject[] panels; // Array to hold references to all panels

    void Start()
    {
        // Attach the Reset method to the button's onClick event
        GetComponent<Button>().onClick.AddListener(Reset);
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
    }
}
