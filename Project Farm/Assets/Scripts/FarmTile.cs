using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTile : MonoBehaviour
{
    GameTileContent content;
    [SerializeField]
    string tileName = null;
    MeshFilter filter;

    [SerializeField]
    Mesh ground = default;

    private void Start()
    {
        filter = gameObject.GetComponent<MeshFilter>();
    }

    public GameTileContent Content
    {
        get => content;
        set
        {
            Debug.Assert(value != null, "Null assigned to content!");
            if (content != null)
            {
                content.Recycle();
                ChangeObject();
            }
            else
                print("none");
            content = value;
            content.transform.localPosition = transform.localPosition;
        }
    }

    public void ChangeObject()
    {
        filter.mesh = ground;
    }

    public string TilePos(int x, int y)
    {
        if(tileName != null)
        {
            tileName = x + " " + y;
        }

        return tileName;
    }
}