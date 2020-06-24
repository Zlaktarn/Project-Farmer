using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UiInventory inventoryUI;

    public Storage pInventory = null;

    int wood;
    public int []supplies;

    int minStack = 1;
    int maxStack = 20;
    int stacksAmount = 0;

    int stack = 0;
    int stackMultiplier = 0;

    private void Start()
    {
        //Used as a test
        GiveItem(1);
    }

    public void Update()
    {
        AmountOfItems(0);


        if (Input.GetKeyDown(KeyCode.O))
        {
            GiveItem(0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            RemoveItem(0);
        }
    }

    public void AmountOfItems(int id)
    {
        supplies[id] = pInventory.wood;

        int stacks = 1 + supplies[id] / 20;

        
        int maxStack = 20 * stackMultiplier;
        int stack = 1 + maxStack;

        int minStack = 20 * stackMultiplier;

        if (supplies[id] >= stack)
        {
            GiveItem(id);
            stackMultiplier += 1;
        }

        if(supplies[id] < maxStack)
        {

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