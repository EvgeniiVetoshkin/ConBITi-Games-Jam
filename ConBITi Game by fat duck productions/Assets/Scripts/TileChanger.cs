using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChanger : MonoBehaviour
{
    public Vector3Int position;
    public TileData data;
    private Tilemap map;
    private TileBase flowerTile;
    



    public TileBase[] tiles;

    private void Start()
    {
        map.SetTile(position, flowerTile);
        
    }
}
