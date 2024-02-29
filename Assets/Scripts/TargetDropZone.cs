using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TargetDropZone : MonoBehaviour, IDropHandler
{
    public Image catImage; // Reference to the Image component representing the cat's appearance
    public ParticleSystem particleEffect; // Reference to the Particle System component representing the effect

    public void OnDrop(PointerEventData eventData)
    {
        if (catImage != null)
        {
            // Get the Image component of the dropped clothing item
            Image draggedImage = eventData.pointerDrag.GetComponent<Image>();
            if (draggedImage != null)
            {
                // Apply the sprite of the dropped clothing item to the cat's appearance
                catImage.sprite = draggedImage.sprite;

                // Play the particle effect
                if (particleEffect != null)
                {
                    particleEffect.Play();
                }
            }
        }
    }
}
