using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeleteItem : MonoBehaviour
{
    public bool InSlot = false;
    public int itemCount;
    [SerializeField] GameObject dragPrefab;
    [SerializeField] GameObject parentObj;

    public GameObject objtToCheck;

    //с точки зрения основного листа (на дроп)
    private void OnMouseOver()
    {
        CraftManager craftManager = FindObjectOfType<CraftManager>();
        if (Input.GetMouseButtonDown(1) & InSlot)
        {
            bool isInInventory = false;
            int indexOfObj = 0;
            foreach(var i in craftManager.craftInventory)
            {
                if (i.GetComponent<DragDrop>().itemData == GetComponent<DragDrop>().itemData)
                {
                    print("Есть в инвентаре");
                    isInInventory = true;
                    indexOfObj = craftManager.craftInventory.IndexOf(i);
                }
            }
            if (isInInventory)
            {
                craftManager.craftInventoryBack[indexOfObj].GetComponent<DeleteItem>().itemCount++;
            }
            else
            {
                print("Создаем новый");
                for(int i = 0; i<craftManager.craftInventory.Count; i++)
                {
                    if (!craftManager.craftInventory[i].activeSelf)
                    {
                        print("found");
                        indexOfObj = i;
                        craftManager.craftInventory[i].SetActive(true);
                        craftManager.craftInventory[i].GetComponent<DeleteItem>().objtToCheck = objtToCheck;
                        craftManager.craftInventoryBack[i].GetComponent<DeleteItem>().itemCount++;
                        craftManager.craftInventory[i].GetComponent<DragDrop>().itemData = GetComponent<DragDrop>().itemData;
                        craftManager.craftInventory[i].GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                        craftManager.craftInventoryBack[i].GetComponent<Image>().sprite = GetComponent<Image>().sprite;
                        break;
                    }
                }
            }
            FindObjectOfType<CraftSystem>().RemoveFromKettle(GetComponent<DragDrop>().itemData);
            ChangeText(craftManager.craftInventoryBack[indexOfObj].transform.parent.transform.GetChild(1).GetComponent<TextMeshProUGUI>(), craftManager.craftInventoryBack[indexOfObj].GetComponent<DeleteItem>().itemCount);
            Destroy(gameObject);
        }
        

    }

    public void ChangeText(TextMeshProUGUI textField, int setTo)
    {
        textField.GetComponent<TextMeshProUGUI>().text = setTo.ToString();
    }

    //с точки зрения доп.листа
    public void Recalculation(DragDrop dataTOSet)
    {
        CraftManager craftManager = FindObjectOfType<CraftManager>();
        itemCount -= 1;
        print("Уменьшилось количество, теперь " + itemCount);
        ChangeText(transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>(), itemCount);
        if (itemCount == 0)
        {
            Destroy(GetComponent<RectTransform>().parent.gameObject);

            craftManager.craftInventory[craftManager.craftInventoryBack.IndexOf(gameObject) + 1].GetComponent<RectTransform>().anchoredPosition = dataTOSet.startPos;
            
            for (int i = craftManager.craftInventoryBack.IndexOf(gameObject) + 2; i < craftManager.craftInventory.Count; i++)
            {
                craftManager.craftInventory[i].GetComponent<RectTransform>().anchoredPosition = craftManager.craftInventory[i-1].GetComponent<DragDrop>().startPos;
            }
            foreach(var i in craftManager.craftInventory)
            {
                i.GetComponent<DragDrop>().startPos = i.GetComponent<RectTransform>().localPosition;
            }
            craftManager.craftInventory.Remove(craftManager.craftInventory[craftManager.craftInventoryBack.IndexOf(gameObject)]);
            craftManager.craftInventoryBack.Remove(gameObject);
        }
        else
        {
            print("Уменьшаем");
            GameObject newDragObj = Instantiate(dragPrefab);
            newDragObj.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
            

            craftManager.craftInventory[craftManager.craftInventoryBack.IndexOf(gameObject)].GetComponent<DeleteItem>().objtToCheck = newDragObj;
            craftManager.craftInventory[craftManager.craftInventoryBack.IndexOf(gameObject)].GetComponent<DeleteItem>().dragPrefab = dragPrefab;
            craftManager.craftInventory[craftManager.craftInventoryBack.IndexOf(gameObject)].GetComponent<DeleteItem>().parentObj = parentObj;

            newDragObj.transform.SetParent(parentObj.transform);
            newDragObj.GetComponent<RectTransform>().anchoredPosition = dataTOSet.startPos;
            newDragObj.GetComponent<DeleteItem>().dragPrefab = dragPrefab;
            newDragObj.GetComponent<DeleteItem>().parentObj = parentObj;
            newDragObj.GetComponent<DragDrop>().startPos=dataTOSet.startPos;
            newDragObj.GetComponent<DragDrop>().canvas=dataTOSet.canvas;
            newDragObj.GetComponent<DragDrop>().itemData=dataTOSet.itemData;
            newDragObj.GetComponent<RectTransform>().localScale = dataTOSet.GetComponent<RectTransform>().localScale;
            craftManager.craftInventory[craftManager.craftInventoryBack.IndexOf(gameObject)].GetComponent<DeleteItem>().objtToCheck = newDragObj;
            newDragObj.GetComponent<DeleteItem>().objtToCheck = craftManager.craftInventory[craftManager.craftInventoryBack.IndexOf(gameObject)];
            craftManager.craftInventory[craftManager.craftInventoryBack.IndexOf(gameObject)] = newDragObj;

            
        }
    }

}
