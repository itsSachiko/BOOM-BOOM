using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    Grid grid;
    [SerializeField] int height, width;
    [SerializeField] Actions actions;
    private void Start()
    {
        //  grid = new Grid(width, height);
    }
}
