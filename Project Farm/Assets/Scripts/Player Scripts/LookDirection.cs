using UnityEngine;

public class LookDirection : MonoBehaviour
{
    [SerializeField]
    GameObject targetObject = null;
    [SerializeField]
    float distance = 4.0f;

    public FarmTile FarmTile = null; //Variable used in Farm.cs to interact with GameTile. 

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

            LookInteractions(targetObject);
            //LFFarmTile(targetObject);

            return targetObject;
        }

        return null;
    }

    public void LookInteractions(GameObject gameObject)
    {
        if(gameObject != null)
        {
            LFFarmTile(gameObject);
            //LFNpc(targetObject);
            
        }
    }

    //Used in Hit() to look if the gameobject the player is looking at is a GameTile
    public FarmTile LFFarmTile(GameObject gameObject)
    {
        FarmTile = gameObject.GetComponent<FarmTile>();

        if (FarmTile != null)
            return FarmTile;
        else
            return null;
    }
}
