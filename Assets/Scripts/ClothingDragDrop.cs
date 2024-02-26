using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClothingDragDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public string bodyPartTag; // Tag of the body part represented by this drop zone
    public Image clothingImage; // Reference to the clothing image connected to this drop zone

    public void OnDrag(PointerEventData eventData)
    {
        // Implement drag behavior
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Implement drop behavior
        Collider2D[] colliders = Physics2D.OverlapPointAll(eventData.position); // Check for overlapping colliders at drop position

        foreach (Collider2D collider in colliders)
        {
            // Check if the collider belongs to a drop zone and has the same tag as the body part
            if (collider.CompareTag(bodyPartTag))
            {
                // Apply the sprite of the connected clothing image to the character
                collider.GetComponent<SpriteRenderer>().sprite = clothingImage.sprite;
                break; // Exit loop after setting sprite
            }
        }
    }
}
