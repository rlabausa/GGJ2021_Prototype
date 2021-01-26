using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public string tileName;
    public Vector3 position;

    public void BuildTile(string name, Vector3 pos)
    {
        this.tileName = name;
        this.position = pos;
    }
}
