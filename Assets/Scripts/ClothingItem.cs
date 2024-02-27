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
            gameObject.SetActive(false); // Deactivate the panel image if it's dragged onto the correct drop zone
            if (bodyImageReference != null && bodySprite != null)
            {
                Debug.Log("Setting body sprite to target image.");
                bodyImageReference.sprite = bodySprite; // Apply the body sprite to the target image
                SetTargetImageAlpha(1f); // Make the target image fully opaque
            }
            else
            {
                Debug.LogWarning("Target image or body sprite is null.");
            }
        }
        else
        {
            transform.SetParent(originalParent); // Set the panel image back to its original parent if it's not dragged onto the correct drop zone
            dragTransform.anchoredPosition = Vector2.zero; // Reset the position of the panel image
        }
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
        Color imageColor = bodyImageReference.color;
        imageColor.a = alpha;
        bodyImageReference.color = imageColor;
    }

    public void ResetState()
    {
        gameObject.SetActive(true); // Activate the ClothingItem GameObject
        transform.SetParent(originalParent); // Reset the parent of the ClothingItem
        dragTransform.anchoredPosition = Vector2.zero; // Reset the position of the ClothingItem
        SetTargetImageAlpha(0f); // Make the target image fully transparent
    }

}
