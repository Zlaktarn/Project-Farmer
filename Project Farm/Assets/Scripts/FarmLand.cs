using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLand : MonoBehaviour
{
    Vector2Int size;
    FarmTile[] tiles;

    float groundOffset;
    Vector3 vectorOffset = Vector3.zero;

    [SerializeField]
    FarmTile tilePrefab = default;

    [SerializeField]
    float SizeModifier = 1f;

    public void Initialize(Vector2Int size)
    {
        this.size = size;

        Vector2 offset = new Vector2((size.x - 1) * 0.5f, (size.y - 1) * 0.5f);
        tiles = new FarmTile[size.x * size.y];
        for (int i = 0, y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++, i++)
            {
                FarmTile tile = tiles[i] = Instantiate(tilePrefab);
                tile.transform.SetParent(transform, false);
                tile.transform.localPosition = new Vector3((x - offset.x) * SizeModifier, 0f, (y - offset.y) * SizeModifier);
                tile.TilePos(x, y);

                //tile.Content = contentFactory.Get(GameTileContentType.Empty);
            }
        }
    }
}
