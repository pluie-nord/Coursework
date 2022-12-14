using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    private Item currentItem;
    public Image customCursor;

    public Slot[] craftingSlots;

    public List<Item> itemList;
    public Item[] recipeResults;
    public Slot resultSlot;

    InventoryItemData craftItem;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (currentItem != null)
            {
                customCursor.gameObject.SetActive(false);
                Slot nearestsSlot = null;
                float shortestDistance = float.MaxValue;

                foreach (Slot slot in craftingSlots)
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);
                    if (dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestsSlot = slot;
                    }
                }
                nearestsSlot.gameObject.SetActive(true);
                nearestsSlot.GetComponent<Image>().sprite = currentItem.GetComponent<Image>().sprite;
                nearestsSlot.item = currentItem;
                itemList[nearestsSlot.index] = currentItem;

                currentItem = null;

                CheckForCreatedRecipes();
            }
        }
    }



    void CheckForCreatedRecipes()
    {
        resultSlot.gameObject.SetActive(false);
        resultSlot.item = null;
        List<int> currentRecipeString = new List<int>(); //List<int> [1,2]
        //sort не рецепт
        //сравнить
        foreach (Item item in itemList)// вместо item IID
        {
            if (item != null)
            {
                currentRecipeString.Add(item.colorID);
            }

        }


        List<List<int>> recipe = new List<List<int>>();
        List<int> list = new List<int>();

        list.Add(1);
        list.Add(2);
        recipe.Add(list);
        list.Clear();

        print(recipe[0].Count);
        currentRecipeString.Sort();

       List<int> currentRecipeStringUnic = new List<int>();
        if (currentRecipeString.Count()>=1)
        currentRecipeStringUnic.Add(currentRecipeString[0]);
        if (currentRecipeString.Count()>=2)
        for (int j=1; j<currentRecipeString.Count(); j++)
        {
            if (currentRecipeString[j] != currentRecipeString[j - 1]) currentRecipeStringUnic.Add(currentRecipeString[j]);
        }
        
        for (int i = 0; i < recipe.Count(); i++)
        {
            if(currentRecipeStringUnic.Count==2)
            {
                print(recipe[i][0] + " " + recipe[i][1] + " " + currentRecipeStringUnic[0] + currentRecipeStringUnic[1]);
                
                if (recipe[i] == currentRecipeStringUnic)
                {
                    resultSlot.gameObject.SetActive(true);
                    resultSlot.GetComponent<Image>().sprite = recipeResults[i].GetComponent<Image>().sprite;
                    resultSlot.item = recipeResults[i];
                    //проверить красители через словарь Dictionary
                }
            }
 
        }
        recipe.Clear();
    }
    public void OnClicSlot(Slot slot)
    {
        slot.item = null;
        itemList[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckForCreatedRecipes();
    }

    public void OuMouseDowmItem(Item item)
    {
        if (currentItem == null)
        {
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;
        }
    }
}