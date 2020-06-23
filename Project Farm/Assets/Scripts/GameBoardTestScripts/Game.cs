using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    Vector2Int boardSize = new Vector2Int(11, 11);

    [SerializeField]
    GameBoard board = default;

    [SerializeField]
    GameTileContentFactory tileContentFactory = default;




    void Awake()
    {
        board.Initialize(boardSize, tileContentFactory);
    }

    void OnValidate()
    {
        if (boardSize.x < 2)
            boardSize.x = 2;
        if (boardSize.y < 2)
            boardSize.y = 2;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            HandleTouch();
        }
    }

    void HandleTouch()
    {
        //FarmTile tile = board.GetTile(TouchRay);
        FarmTile tile = Hit();
        if (tile != null)
        {
            tile.Content = tileContentFactory.Get(GameTileContentType.Dug);
        }
        else
            print("Didn't work");
    }

    public FarmTile Hit()
    {
        int playerLayer = LayerMask.NameToLayer("Player");
        int layerMask = 1 << playerLayer;
        layerMask = ~layerMask;
        Transform targetObject;
        FarmTile targetFarmTile;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, layerMask))
        {
            targetObject = hit.transform;

            targetFarmTile = targetObject.GetComponent<FarmTile>();

            if (targetFarmTile != null)
                return targetFarmTile;
            else
            {
                print("Derp");
                return null;
            }
        }
        else
            return null;
    }
}