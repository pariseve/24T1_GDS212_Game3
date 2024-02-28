using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClothingItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform originalParent; // reference to the original parent transform of the panel image
    public Sprite bodySprite; // sprite to be applied to the body part
    public Image bodyImageReference; // reference to the target image component
    public TargetDropZone dropZone;

    private RectTransform dragTransform;
    private bool isDragging;
    private bool isCorrectDrop;
    private Vector3 originalLocalPosition; // Store the original local position here
    private Sprite originalSprite; // Store the original sprite here
    private Sprite currentSprite; // Store the current sprite here

    void Start()
    {
        dragTransform = GetComponent<RectTransform>();
        originalParent = transform.parent; // Set the original parent as the initial parent transform

        // Ensure that the targetImage is properly set
        if (bodyImageReference == null)
        {
            bodyImageReference = GetComponent<Image>(); // Get the Image component if not assigned
        }

        if (bodyImageReference != null)
        {
            SetTargetImageAlpha(0f); // Make the target image fully transparent at start
        }

        // Store the original local position at the start
        originalLocalPosition = transform.localPosition;

        // Store the original sprite
        if (bodyImageReference != null)
        {
            originalSprite = bodyImageReference.sprite;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        isCorrectDrop = false; // reset the flag indicating correct drop at the beginning of drag
    }

    public void OnDrag(PointerEventData eventData)
    {
        //moving the item icon
        if (isDragging)
        {
            dragTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor; // move the panel image with the mouse
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;

        if (isCorrectDrop)
        {
            Debug.Log("Correct drop detected.");
            if (bodyImageReference != null && bodySprite != null)
            {
                // Reset the previous sprite to its original state
                if (currentSprite != null)
                {
                    bodyImageReference.sprite = originalSprite;
                    currentSprite = null;
                }

                // Assign the new sprite to bodyImageReference
                Debug.Log("Setting body sprite to target image.");
                bodyImageReference.sprite = bodySprite; // Apply the body sprite to the target image
                currentSprite = bodySprite; // Update the current sprite
                SetTargetImageAlpha(1f); // Make the target image fully opaque
            }
            else
            {
                Debug.LogWarning("Target image or body sprite is null.");
            }
        }

        // Return the clothing item to its original parent and position
        transform.SetParent(originalParent);
        transform.localPosition = originalLocalPosition; // Return to original local position
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isDragging)
        {
            Debug.Log("its doing something here");
            isCorrectDrop = true; // Set the flag indicating correct drop when the panel image enters the drop zone
            foreach (GameObject obj in eventData.hovered)
            {
                Debug.Log(obj.name);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isDragging)
        {
            isCorrectDrop = false; // Reset the flag indicating correct drop when the panel image exits the drop zone
        }
    }

    // method to set the alpha value of the target image
    private void SetTargetImageAlpha(float alpha)
    {
        if (bodyImageReference != null)
        {
            Color imageColor = bodyImageReference.color;
            imageColor.a = alpha;
            bodyImageReference.color = imageColor;
        }
    }

    public void ResetState()
    {
        gameObject.SetActive(true); // Activate the ClothingItem GameObject
        transform.SetParent(originalParent); // Reset the parent of the ClothingItem
        transform.localPosition = originalLocalPosition; // Reset the position of the ClothingItem
        if (bodyImageReference != null)
        {
            bodyImageReference.sprite = originalSprite; // Reset the sprite to its original state
            SetTargetImageAlpha(0f); // Make the target image fully transparent
        }
    }
}
