using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler {

    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<DeleteItem>().InSlot = true;
            FindObjectOfType<CraftSystem>().AddToKettle(eventData.pointerDrag.GetComponent<DragDrop>().itemData);
            eventData.pointerDrag.GetComponent<DragDrop>().GetAccordingBackItem().Recalculation(eventData.pointerDrag.GetComponent<DragDrop>());
        }
    }

}
