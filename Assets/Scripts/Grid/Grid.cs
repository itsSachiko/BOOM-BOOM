using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private int[,] gridArray;
    public TileChecker[,] tileCheckers;
    private GameObject tileCheck;
    private bool hasPlayer, hasWall, hasIndestrucruble;
    private Actions actions;
    public Grid(int width, int height, GameObject tileCheck)
    {
        this.width = width;
        this.height = height;
        this.tileCheck = tileCheck;

        gridArray = new int[width, height];
       

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++) 
            {
                GameObject newTileCheck = MonoBehaviour.Instantiate(tileCheck, GetWorldPos(x, y), Quaternion.identity);
                tileCheckers[x,y] = newTileCheck.GetComponent<TileChecker>();
                
            }
        }


    }

    private Vector3 GetWorldPos(int x, int y)
    {
        return new Vector3(x, y);
    }
}
