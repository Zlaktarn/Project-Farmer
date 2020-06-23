using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UiInventory inventoryUI;

    private void Start()
    {
        //Used as a test
        GiveItem(0);
        GiveItem(1);
        GiveItem(0);
    }

    //Adds items into the Inventory.
    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.title);
    }

    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    //Haven't been implemented to use yet. But would be used to remove items.
    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if(itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
            Debug.Log("Item removed: " + itemToRemove.title);
        }
    }
}
