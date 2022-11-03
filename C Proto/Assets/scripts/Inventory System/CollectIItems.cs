using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectIItems : MonoBehaviour, IItem
{
    public float accessRange = 1f;
    public LayerMask playerLayer;
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
            if (Physics2D.OverlapCircleAll(transform.position, accessRange, playerLayer).Length!=0)
            {
                inventoryManager.Add(itemData);
                InventorySystem.ItemCollected(this);
                Destroy(gameObject);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, accessRange);
    }
}
