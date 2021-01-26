using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public int width;
    public int height;
    public Dictionary<Vector3, Tile> tiles;
    public float scalar;
    public GameObject tilePrefab;

    public void BuildGameGrid()
    {
        tiles = new Dictionary<Vector3, Tile>();

        int index = 0;
        for (int x = 0; x < this.height; x++)
        {
            for (int z = 0; z < this.width; z++)
            {
                Vector3 tilePosition = scalar * new Vector3(x, 0, z);
                string tileName = string.Format("tile_{0}", index);

                // Create tile
                //TODO: Determine if there is a better way to create the Tile object
                Tile tile = gameObject.AddComponent<Tile>();
                tile.BuildTile(tileName, tilePosition);
                tiles.Add(tilePosition, tile);

                // Move instantiated prefabs under GameGrid object in scene hierarchy
                GameObject tilePrefabGO = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                tilePrefabGO.transform.parent = gameObject.transform;

                index++;
            }
        }
    }

}
