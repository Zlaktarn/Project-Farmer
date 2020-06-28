using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Canvas inventory;

    public static bool inventoryOpen; //Me being lazy

    [SerializeField]
    LookDirection look = default;

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
            if (look.LocateTarget())
            {
                look.LFFarmTile();
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if(look.LocateTarget())
            {
                look.LFChest();
                look.LFNpc();
            }
        }
    }

    private void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(!inventoryOpen)
            {
                inventory.enabled = true;
                inventoryOpen = true;
            }
            else
            {
                inventory.enabled = false;
                inventoryOpen = false;
            }
        }
    }
}
