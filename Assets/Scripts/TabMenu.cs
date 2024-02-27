using UnityEngine;
using UnityEngine.UI;

public class TabMenu : MonoBehaviour
{
    public GameObject[] panels; // Array to hold references to all panels
    public Button[] tabButtons; // Array to hold references to all tab buttons

    private void Start()
    {
        // Assign onClick listeners to all tab buttons
        for (int i = 0; i < tabButtons.Length; i++)
        {
            int panelIndex = i; // Capturing current index to avoid closure issues
            tabButtons[i].onClick.AddListener(() => TogglePanel(panelIndex));
        }
    }

    // Method to toggle the visibility of panels
    void TogglePanel(int panelIndex)
    {
        // Deactivate all panels
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }

        // Activate the selected panel
        panels[panelIndex].SetActive(true);
    }
}
