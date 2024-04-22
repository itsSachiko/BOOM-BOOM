using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent
{
    InputsComponent inputs;
    MoveData moveData;
    Transform movingObject;
    Animator anim;
    float timer = 0;
    LayerMask layer;
    Vector2 lerpPos;

    public MovementComponent(InputsComponent inputs, MoveData moveData, Transform movingObject, Animator anim)
    {
        this.inputs = inputs;
        this.moveData = moveData;
        this.movingObject = movingObject;
        this.anim = anim;
        this.timer = 0;
        inputs.moveObject = movingObject;
        this.layer = moveData.layer;
        lerpPos = Vector2.zero;
    }

    public void Tick()
    {
        if (inputs.xAxis != 0)
        {
            inputs.isLerping = true;
            Debug.DrawRay(movingObject.position, inputs.xAxis * Vector2.right, Color.red, 3f);
            if (!Physics2D.Raycast(movingObject.position, inputs.xAxis * Vector2.right, 1f, layer) && timer < moveData.lerpDuration)
            {
                Debug.Log("GOGOOGOGO");
                lerpPos = Vector2.Lerp(inputs.startPos, new Vector2 (inputs.endPos.x, movingObject.position.y), timer/moveData.lerpDuration);
                movingObject.position = lerpPos;
                timer += Time.deltaTime;
            }
            

            else
            {
                timer = 0;
                
                inputs.isLerping = false;
            }
        }

        else if (inputs.yAxis != 0)
        {
            inputs.isLerping = true;
            Debug.DrawRay(movingObject.position, inputs.yAxis * Vector2.up, Color.black, 3f);
            if (!Physics2D.Raycast(movingObject.position, inputs.yAxis * Vector2.up, 1f, layer) && timer < moveData.lerpDuration)
            {
                lerpPos = Vector2.Lerp(inputs.startPos, new Vector2(movingObject.position.x, inputs.endPos.y ), timer / moveData.lerpDuration);
                movingObject.position = lerpPos;
                timer += Time.deltaTime;
            }

            else
            {
                timer = 0;
                
                inputs.isLerping = false;
            }
        }

    }
}

