using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectIItems : MonoBehaviour, IItem
{
    [SerializeField] InventoryItemData itemData;
    public int ID { get; set; }
    private InventorySystem inventoryManager;

    private void Start()
    {
        inventoryManager = FindObjectOfType<InventorySystem>();
        ID = int.Parse(itemData.id);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GetComponent<ObjectInteraction>().toActivate)
            {
                inventoryManager.Add(itemData);
                InventorySystem.ItemCollected(this);
                Destroy(gameObject);
            }
        }
    }
}
