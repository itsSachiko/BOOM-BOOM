using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InputsComponent
{
    public float xAxis {  get; set; }
    public float yAxis { get; set; }
    public bool bombPlaced {  get; set; }
    public bool isLerping { get; set; }

    public Vector2 startPos { get; set; }
    public Vector2 endPos { get; set; }

    public Transform moveObject { get; set; }

    public void Movement();
    public void BombPlacing();
}

public class PlayerInputs : InputsComponent
{
    public float xAxis { get; set; }
    public float yAxis { get; set; }
    public bool bombPlaced { get ; set ; }
    public bool isLerping { get; set; }
    public Vector2 startPos { get; set; }
    public Vector2 endPos { get; set; }
    public Transform moveObject { get; set; }

    public void BombPlacing()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bombPlaced = true;
        }
    }

    public void Movement()
    {
        if (isLerping)
        {
            
            return;
        }
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        startPos = moveObject.position;
        //endPos = startPos + new Vector2(xAxis, yAxis);
    }
}

public class EnemyInput : InputsComponent
{
    public float xAxis { get; set; }
    public float yAxis { get; set; }
    public bool bombPlaced { get; set; }
    public bool isLerping { get; set; }
    public Vector2 startPos { get; set; }
    public Vector2 endPos { get; set; }
    public Transform moveObject { get; set; }

    public void BombPlacing()
    {
        bombPlaced = false;
    }

    public void Movement()
    {
        if (isLerping)
        {
            return;
        }

        xAxis = Random.Range(-1, 2);
        yAxis = Random.Range(-1, 2);
        startPos = moveObject.position;
        endPos = startPos + new Vector2(xAxis, yAxis);

    }
}



