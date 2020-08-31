using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Canvas inventoryCanvas;

    public static bool inventoryOpen; //Me being lazy

    [SerializeField]
    LookDirection look = default;

    [SerializeField]
    Animator anim;

    Storage inventory;

    float timer = 0;
    [SerializeField]
    float digInterval = 2f;

    public bool digging = false;

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

    private bool Digging(FarmTile farmTile)
    {

        anim.SetBool("Digging", true);
        timer += Time.deltaTime;
        digging = true;

        if (timer >= digInterval)
        {
            farmTile.DugTile();
            timer = 0;

            return false;
        }
        else
            return true;
    }

    private void Action()
    {
        if (look.LocateTarget())
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (look.LFFarmTile() != null && look.LFFarmTile().type != GameTileContentType.Dug)
                {
                    Digging(look.LFFarmTile());
                }
                else
                {
                    anim.SetBool("Digging", false);
                    digging = false;
                }
            }
           

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (look.LocateTarget())
                {
                    look.LFChest();
                    look.LFNpc();
                    look.LFObject();

                    if (look.LootId >= 0)
                    {
                        inventory.resources[look.LootId] += 1;
                    }
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
