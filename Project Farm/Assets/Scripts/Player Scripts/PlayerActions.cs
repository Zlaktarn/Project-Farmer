using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameObject inventory;

    public static bool inventoryOpen; //Me being lazy

    void Update()
    {
        Actions();
    }

    private void Actions()
    {
        Loot();
        Action();
        OpenInventory();
    }

    private void Loot()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            print("Loots target");
        }
    }

    private void Action()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
        }
    }


    private void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(!inventoryOpen)
            {
                print("Opened Inventory");
                inventory.SetActive(true);
                inventoryOpen = true;
            }
            else
            {
                print("Closed Inventory");
                inventory.SetActive(false);
                inventoryOpen = false;
            }
            
        }
    }
}
