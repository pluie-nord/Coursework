using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resipe Data")]
public class RecipeData : ScriptableObject
{
    public List<int> recipe;
    public Sprite craftModeIcon;
    public InventoryItemData inventoryItemData;
    public string color;
}
