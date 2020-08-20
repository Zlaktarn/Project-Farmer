using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Canvas inventoryCanvas;

    public static bool inventoryOpen; //Me being lazy

    [SerializeField]
    LookDirection look = default;

    Storage inventory;

    private void Start()
    {
        inventory = gameObject.GetComponent<Storage>();
    }

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
                look.LFObject();

                if(look.LootId >= 0)
                {
                    inventory.resources[look.LootId] += 1;
                }
            }
        }
    }

    private void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(!inventoryOpen)
            {
                inventoryCanvas.enabled = true;
                inventoryOpen = true;
            }
            else
            {
                inventoryCanvas.enabled = false;
                inventoryOpen = false;
            }
        }
    }
}
