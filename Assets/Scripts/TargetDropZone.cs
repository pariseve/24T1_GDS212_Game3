using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TargetDropZone : MonoBehaviour, IDropHandler
{
    public Image catImage; // Reference to the Image component representing the cat's appearance

    public void OnDrop(PointerEventData eventData)
    {
        if (catImage != null)
        {
            Debug.Log("Somehow hitting this script");
            // Get the Image component of the dropped clothing item
            Image draggedImage = eventData.pointerDrag.GetComponent<Image>();
            if (draggedImage != null)
            {
                // Apply the sprite of the dropped clothing item to the cat's appearance
                catImage.sprite = draggedImage.sprite;
            }
        }
    }
    //sam 
}
