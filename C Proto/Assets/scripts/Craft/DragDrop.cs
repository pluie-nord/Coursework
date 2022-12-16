using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] public Canvas canvas;
    [SerializeField] public InventoryItemData itemData;
    public Vector3 startPos;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private CraftManager craftManager;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        craftManager=FindObjectOfType<CraftManager>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
    }

    public DeleteItem GetAccordingBackItem()
    {
        return craftManager.craftInventoryBack[craftManager.craftInventory.IndexOf(gameObject)].GetComponent<DeleteItem>();
    }

}
