using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClothingItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Collider2D correctCollider; // reference to the correct collider for the drop zone
    public Transform originalParent; // reference to the original parent transform of the panel image
    public Sprite bodySprite; // sprite to be applied to the body part
    public Image targetImage; // reference to the target image component

    private RectTransform dragTransform;
    private bool isDragging;
    private bool isCorrectDrop;

    void Start()
    {
        dragTransform = GetComponent<RectTransform>();
        originalParent = transform.parent; // Set the original parent as the initial parent transform

        // Ensure that the targetImage is properly set
        if (targetImage == null)
        {
            targetImage = GetComponent<Image>(); // Get the Image component if not assigned
        }

        if (targetImage != null)
        {
            SetTargetImageAlpha(0f); // Make the target image fully transparent at start
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        isCorrectDrop = false; // reset the flag indicating correct drop at the beginning of drag
    }

    public void OnDrag(PointerEventData eventData)
    {
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
            gameObject.SetActive(false); // Deactivate the panel image if it's dragged onto the correct collider
            if (targetImage != null && bodySprite != null)
            {
                Debug.Log("Setting body sprite to target image.");
                targetImage.sprite = bodySprite; // Apply the body sprite to the target image
                SetTargetImageAlpha(1f); // Make the target image fully opaque
            }
            else
            {
                Debug.LogWarning("Target image or body sprite is null.");
            }
        }
        else
        {
            transform.SetParent(originalParent); // Set the panel image back to its original parent if it's not dragged onto the correct collider
            dragTransform.anchoredPosition = Vector2.zero; // Reset the position of the panel image
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDragging && other == correctCollider)
        {
            isCorrectDrop = true; // set the flag indicating correct drop when the panel image enters the correct collider
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == correctCollider)
        {
            isCorrectDrop = false; // reset the flag indicating correct drop when the panel image exits the correct collider
        }
    }

    // method to set the alpha value of the target image
    private void SetTargetImageAlpha(float alpha)
    {
        Color imageColor = targetImage.color;
        imageColor.a = alpha;
        targetImage.color = imageColor;
    }
}
