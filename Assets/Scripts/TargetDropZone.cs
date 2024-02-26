using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClothingDropZone : MonoBehaviour, IDropHandler
{
    public Image targetImage; 

    public void OnDrop(PointerEventData eventData)
    {
        if (targetImage != null)
        {
            // get the sprite of the dropped clothing item
            Image draggedImage = eventData.pointerDrag.GetComponent<Image>();
            if (draggedImage != null)
            {
                // apply the sprite of the dropped clothing item to the target image
                targetImage.sprite = draggedImage.sprite;
            }
        }
    }
}
