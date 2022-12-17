using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    [SerializeField] List<InventoryItemData> items;
    [SerializeField] GameObject CraftScreen;
    [SerializeField] GameObject MainScreen;
    public List<GameObject> craftInventory;
    public List<GameObject> craftInventoryBack;
    private InventorySystem inventorySystem;
    void Start()
    {
        inventorySystem=FindObjectOfType<InventorySystem>();   
        for(int i = 0; i < craftInventory.Count; i++)
        {
            craftInventory[i].GetComponent<DragDrop>().startPos = craftInventory[i].GetComponent<RectTransform>().localPosition;
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & CraftScreen.activeSelf)
        {
            foreach (var i in FindObjectsOfType<DeleteItem>())
            {
                if (i.InSlot)
                {
                    Destroy(i.gameObject);
                }
            }
            FindObjectOfType<CraftSystem>().ResetColorant();
            CraftScreen.SetActive(false);
            MainScreen.SetActive(true);
        }
    }

    public void OpenCraft()
    {
            CraftScreen.SetActive(true);
            MainScreen.SetActive(false);
            List<InventoryItem> inventoryForCraft = inventorySystem.inventory;
            /*foreach(var i in inventorySystem.inventory)
            {
                if(i.data.ColorCount==0)
                {
                    inventoryForCraft.Remove(i);
                }
            }*/
            for(int i = 0; i< inventorySystem.inventory.Count; i++)
            {
                if (inventorySystem.inventory[i].data.ColorCount == 0)
                {
                    inventoryForCraft.Remove(inventorySystem.inventory[i]);
                }
            }

            for(int i =0; i< inventoryForCraft.Count; i++)
            {
                craftInventory[i].SetActive(true);
                craftInventory[i].GetComponent<Image>().sprite = inventoryForCraft[i].data.icon;
                craftInventoryBack[i].GetComponent<Image>().sprite = inventoryForCraft[i].data.icon;
                craftInventoryBack[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                craftInventory[i].GetComponent<DragDrop>().itemData = inventoryForCraft[i].data;
                craftInventoryBack[i].GetComponent<DeleteItem>().itemCount = inventoryForCraft[i].stackSize;
                craftInventoryBack[i].GetComponent<DeleteItem>().ChangeText(craftInventoryBack[i].transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>(), craftInventoryBack[i].GetComponent<DeleteItem>().itemCount);
            }
    }

}
