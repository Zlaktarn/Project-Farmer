using UnityEngine;

public class LookDirection : MonoBehaviour
{
    [SerializeField]
    float distance = 4.0f;

    public FarmTile farmTile = null; //Variable used in Farm.cs to interact with GameTile. 
    public NpcScript Npc = null;
    public LootObject Loot = null;
    public int LootId = -1;
    GameObject targetObject = null;

    void LateUpdate()
    {
        targetObject = Hit();
    }

    //Raycast for detecting what GameObject the player character is looking at.
    //It looks in the direction from the PoV based on position of the Camera
    public GameObject Hit()
    {
        int playerLayer = LayerMask.NameToLayer("Player");
        int layerMask = 1 << playerLayer;
        layerMask = ~layerMask;
        GameObject targetObject;

        RaycastHit hit;

        //Test to visualize the player's interaction range
        Vector3 forward = transform.TransformDirection(Vector3.forward) * distance; 

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, layerMask))
        {
            Debug.DrawRay(transform.position, forward, Color.red);
            targetObject = hit.collider.gameObject;

            return targetObject;
        }

        return null;
    }

    public bool LocateTarget()
    {
        if (targetObject != null)
            return true;
        else
        {
            print("No object in sight");
            return false;
        }
    }

    public GameObject LFChest()
    {
        if (targetObject.name == "Chest")
        {
            print("We found a chest yoo!");
            return targetObject;
        }
        else
            return null;
    }

    public NpcScript LFNpc()
    {
        Npc = targetObject.GetComponent<NpcScript>();

        if (Npc != null)
        {
            print("We found a NPC yoo!");
            return Npc;
        }
        else
            return null;
    }

    public LootObject LFObject()
    {
        Loot = targetObject.GetComponent<LootObject>();

        if (Loot != null)
        {
            LootId = Loot.lootId;
            Loot.PickUp();
            return Loot;
        }
        else
        {
            LootId = -1;
            return null;
        }
    }


    //Used in Hit() to look if the gameobject the player is looking at is a GameTile
    public FarmTile LFFarmTile()
    {
        farmTile = targetObject.GetComponent<FarmTile>();

        if (farmTile != null)
        {
            print("Oooh! I see a farmtile!");
            return farmTile;
        }
        else
            return null;
    }
}
