using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    [SerializeField]
    Vector2Int boardSize = new Vector2Int(11, 11);

    [SerializeField]
    LookDirection player = null;

    void Awake()
    {
        FarmLand board = gameObject.GetComponent<FarmLand>();
        board.Initialize(boardSize);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            HandleTouch();
        }
    }

    private void HandleTouch()
    {
        FarmTile tile = player.FarmTile;
        if (tile != null)
        {
            //Destroy(board.gameObject);
            tile.ChangeObject();
        }
    }
}
