using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{

    public int width;
    public int height;
    public Dictionary<Vector3, Tile> tiles;
    public float scalar;

    public void BuildGameGrid(int w, int h, float s)
    {
        this.width = w;
        this.height = h;
        this.tiles = new Dictionary<Vector3, Tile>();
        this.scalar = s;

        int index = 0;
        for (int x = 0; x < this.height; x++)
        {
            for (int z = 0; z < this.width; z++)
            {
                Vector3 tilePosition = scalar * new Vector3(x, 0, z);
                string tileName = string.Format("tile_{0}", index);
                Tile tile = gameObject.AddComponent<Tile>();
                tile.BuildTile(tileName, tilePosition);
                tiles.Add(tilePosition, tile);

                index++;
            }
        }
    }

    public void DrawGameGrid(GameObject tilePrefab)
    {
        foreach (KeyValuePair<Vector3, Tile> kvp in this.tiles)
        {
            Debug.Log(string.Format("Key: {0} Value: {1}", kvp.Key, kvp.Value));

            Vector3 tilePosition = kvp.Key;
            Tile tile = kvp.Value;

            Instantiate(tilePrefab, tilePosition, Quaternion.identity);
        }
    }
}
