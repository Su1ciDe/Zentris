using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Vector2 boardGridSize;
    [SerializeField] private List<Material> tileMaterials = new List<Material>();

    private List<TableTile> tableTiles;

    void Start()
    {
        InitTable();
    }

    void Update()
    {

    }

    private void InitTable()
    {
        tableTiles = new List<TableTile>();

        for (int y = 0; y < boardGridSize.y; y++)
        {
            float offsetY = (int)(-boardGridSize.y / 2) + (boardGridSize.y % 2 == 0 ? y + .5f : y);

            for (int x = 0; x < boardGridSize.x; x++)
            {
                float offsetX = (int)(-boardGridSize.x / 2) + (boardGridSize.x % 2 == 0 ? x + .5f : x);

                GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Cube);
                tile.transform.parent = transform;
                tile.name = "tile_" + x + "x" + y;
                tile.tag = TagEnums.Tile.ToString();
                tile.transform.localScale = new Vector3(1, .1f, 1);
                tile.transform.localPosition = new Vector3(offsetX, 0, offsetY);

                MeshRenderer tileMesh = tile.GetComponent<MeshRenderer>();
                tileMesh.material = tileMaterials[(x + y) % tileMaterials.Count];

                TableTile tableTile = tile.AddComponent<TableTile>();

                tableTiles.Add(tableTile);
            }
        }
    }
}
