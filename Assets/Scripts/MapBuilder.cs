using UnityEngine;
using UnityEngine.Tilemaps;

public class MapBuilder : MonoBehaviour {

    public TileBase[] floorTile;

    Tilemap map;

    //base floor position
    const int floorTileY = -6;

    private void Awake()
    {
        map = GetComponent<Tilemap>();

        map.ClearAllTiles();

        Random.InitState(1);

        for (int i = -10; i < 1200; i++)
        {
            PlaceTile(i, floorTileY, .95f);  //one in every 20 x positions will have no tiles
        }
        
    }

    private void PlaceTile(int x, int y, float chance)
    {
        if (Random.Range(0f, 1f) < chance){ 

            map.SetTile(new Vector3Int(x, y, 0), floorTile[Random.Range(floorTile.GetLowerBound(0), floorTile.GetUpperBound(0) + 1)]);
            PlaceTile(x, y + 1, chance / 2f);   //decreasing chance of tiles
        }
    }
}
