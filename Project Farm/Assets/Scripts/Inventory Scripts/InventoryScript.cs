using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UiInventory inventoryUI;

    public Storage pInventory = null;

    public int []supplies;
    int[] stackMultiplier = new int[2];

    private void Start()
    {
        for (int i = 0; i < stackMultiplier.Length; i++)
        {
            stackMultiplier[i] = 0;
        }
    }

    public void Update()
    {
        AmountOfItems(0, pInventory.resources[0], 20); //Wood
        AmountOfItems(1, pInventory.resources[1], 20); //Ore
    }

    public void AmountOfItems(int id, int resource, int maxStack)
    {
        supplies[id] = resource;

        if ((maxStack * stackMultiplier[id] - supplies[id]) < 0)
        {
            GiveItem(id);
            ++stackMultiplier[id];
        }
        else if ((maxStack * stackMultiplier[id] - supplies[id]) > maxStack || supplies[id] <= 0 && stackMultiplier[id] > 0)
        {
            RemoveItem(id);
            --stackMultiplier[id];
        }
    }

    //Adds items into the Inventory.
    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.title);
    }

    //Used in RemoveItem to look for a specific item and remove it.
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