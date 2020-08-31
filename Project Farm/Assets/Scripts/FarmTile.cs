using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTile : MonoBehaviour
{
    GameTileContent content;
    [SerializeField]
    string tileName = null;
    MeshFilter filter;
    public GameTileContentType type = default;

    [SerializeField]
    Material groundMat = default;
    [SerializeField]
    Material dugMat = default;

    Renderer render = default;

    private void Start()
    {
        filter = gameObject.GetComponent<MeshFilter>();
        render = GetComponent<Renderer>();
        render.material = groundMat;
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

    public void DugTile()
    {
        type = GameTileContentType.Dug;
        render.material = dugMat;
    }


    public void ChangeObject()
    {

    }

    public string TilePos(int x, int y)
    {
        if(tileName != null)
        {
            tileName = x + ", " + y;
        }

        return tileName;
    }
}