using System;
using System.Collections.Generic;
using UnityEngine;

public class Gameboard2 : MonoBehaviour
{
    static public Gameboard2 Active;

    [SerializeField]
    protected GameObject hexTilePrefab;

    private GameObject[] tiles;

    /// <summary>
    /// Sets active board, on initialization or after script recompilation. 
    /// </summary>
    void OnEnable()
    {
        Active = this;

    }

    public void GenerateMap(int height, int width)
    {
        if (tiles != null) {
            foreach (GameObject tile in tiles) {
                Destroy(tile);
            }
        }
        tiles = new GameObject[height * width];
        int tileIndex = 0;
        for (int row = 0; row < height; row++) {
            for (int col = 0; col < width; col++) {
                float xPos = (row * 3.4f);
                float yPos = col;
                if (col % 2 == 1) {
                    xPos += 1.7f;
                }
                var position = new Vector3(xPos, 0, yPos);
                var tile = Instantiate(hexTilePrefab, position, Quaternion.identity, transform);

                tile.name = string.Format("Hex Cell {0}:{1}", row, col);
                tiles[tileIndex++] = tile;
            }
        }
    }
}
