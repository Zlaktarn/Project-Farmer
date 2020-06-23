using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField]
    Transform ground = default;
    Vector2Int size;
    FarmTile[] tiles;

    float groundOffset;
    Vector3 vectorOffset = Vector3.zero;

    [SerializeField]
    FarmTile tilePrefab = default;

    GameTileContentFactory contentFactory;

    void Awake()
    {
        groundOffset = 0.6f /*(-groundHeight / 2) - tilePrefabHeight*/;

        vectorOffset.y = groundOffset;
        gameObject.transform.position = vectorOffset;
        //tilePrefab = farmObject.GetComponent<FarmTile>();
    }

    public void Initialize(Vector2Int size, GameTileContentFactory contentFactory)
    {
        this.size = size;
        this.contentFactory = contentFactory;
        ground.localScale = new Vector3(size.x, 1f, size.y);

        Vector2 offset = new Vector2(
            (size.x - 1) * 0.5f, (size.y - 1) * 0.5f
        );
        tiles = new FarmTile[size.x * size.y];
        for (int i = 0, y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++, i++)
            {
                FarmTile tile = tiles[i] = Instantiate(tilePrefab);
                tile.transform.SetParent(transform, false);
                tile.transform.localPosition = new Vector3((x* 2) - offset.x * 2, 0f, (y*2) - offset.y);

                tile.Content = contentFactory.Get(GameTileContentType.Empty);
            }
        }
    }
}
