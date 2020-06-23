using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();


    private void Awake()
    {
        BuildDatabase(); 
    }

    //Method used in the Item.cs to get item from the items list.
    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    //Create items and adds to the items list
    void BuildDatabase()
    {
        items = new List<Item>()
        {
            (new Item(0, "Wood", "Resources gathered from trees.")),
            (new Item(1, "ore_diamond", "Resources gathered from trees."))
        };
    }
}
