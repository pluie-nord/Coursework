using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class CraftSystem : MonoBehaviour
{
    public List<int> UnicItems = new List<int>();
    public int[] colorNumbers = new int[3] { 0, 0, 0 };

    [SerializeField] public TextMeshProUGUI[] colorantTxt = new TextMeshProUGUI[3];
    [SerializeField] TextMeshProUGUI colorName;
    [SerializeField] TextMeshProUGUI colorCount;
    [SerializeField] Image colorImg;
    [SerializeField] Button craftBtn;

    public List<RecipeData> Recipes;
    private InventorySystem inventorySystem;
    private RecipeData currentRecipe;
    void Start ()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
    }
    public void AddToKettle(InventoryItemData itemData)
    {
        if (!UnicItems.Contains(itemData.ColorID))
        {
            UnicItems.Add(itemData.ColorID);
        }
        colorNumbers[itemData.ColorID] += itemData.ColorCount;
        colorantTxt[itemData.ColorID].text = colorNumbers[itemData.ColorID].ToString();
        Evaluate();
    }

    public void RemoveFromKettle(InventoryItemData itemData)
    {
        if(colorNumbers[itemData.ColorID] != 0)
            colorNumbers[itemData.ColorID] -= itemData.ColorCount;
        colorantTxt[itemData.ColorID].text = colorNumbers[itemData.ColorID].ToString();
        if (colorNumbers[itemData.ColorID]==0)
        {
            UnicItems.Remove(itemData.ColorID);
        }
        Evaluate();
    }

    public void Evaluate()
    {
        foreach(RecipeData recipe in Recipes)
        {
            if(Enumerable.SequenceEqual(recipe.recipe.OrderBy(e=>e), UnicItems.OrderBy(e=>e)))
            {
                colorName.text = recipe.color;
                colorImg.sprite = recipe.craftModeIcon;
                colorImg.color = new Color32(255, 255, 255, 255);
                if (colorNumbers[recipe.recipe[0]]== colorNumbers[recipe.recipe[1]])
                {
                    colorCount.text = colorNumbers[recipe.recipe[0]].ToString();
                    craftBtn.interactable = true;
                    currentRecipe = recipe;
                }
                else
                {
                    craftBtn.interactable = false;
                }
            }
            else
            {
                colorCount.text = "0";
                colorName.text = null;
                colorImg.sprite = null;
                colorImg.color = new Color32(255, 255, 255, 0 );
            }
        }
    }

    public void StartCraft()
    {
        craftBtn.interactable = false;
        print("Вы создали краску!");
        for(int i = 0; i < colorNumbers.Max(); i++)
        {
            inventorySystem.Add(currentRecipe.inventoryItemData);
        }

        colorCount.text = "0";
        colorName.text = null;
        colorImg.sprite = null;
        
        ResetColorant();
        foreach(var i in FindObjectsOfType<DeleteItem>())
        {
            if(i.InSlot)
            {
                inventorySystem.Remove(i.GetComponent<DragDrop>().itemData);
                Destroy(i.gameObject);
            }
        }
    }

    public void ResetColorant()
    {
        foreach(TextMeshProUGUI colorant in colorantTxt)
        {
            
            colorant.text = "0";
        }
        UnicItems.Clear();
        colorNumbers = new int[3] { 0, 0, 0 };
        colorImg.color = new Color32(0, 0, 0, 0);
        colorCount.text = "0";
        colorName.text = null;
        colorImg.sprite = null;
    }

}
