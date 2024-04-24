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
    float timerInput;
    SpriteRenderer spriteRenderer;


    public MovementComponent(InputsComponent inputs, MoveData moveData, Transform movingObject, Animator anim, SpriteRenderer spriteRenderer)
    {
        this.inputs = inputs;
        this.moveData = moveData;
        this.movingObject = movingObject;
        this.anim = anim;
        this.timer = 0;
        inputs.moveObject = movingObject;
        this.layer = moveData.layer;
        lerpPos = Vector2.zero;
        timerInput = moveData.cooldownDuration;
        this.spriteRenderer = spriteRenderer;
    }

    public void Tick()
    {
        
        if (timerInput < moveData.cooldownDuration)
        {
            if (timerInput > 0)
            {

                timerInput -= Time.deltaTime;
                return;
            }
            else
            {
                timerInput = moveData.cooldownDuration;
            }
        }

        if (inputs.xAxis != 0)
        {
            anim.SetBool("isRunning", true);
            inputs.isLerping = true;
            Debug.DrawRay(movingObject.position, inputs.xAxis * Vector2.right, Color.red, 3f);
            inputs.endPos = inputs.startPos + inputs.xAxis * Vector2.right;
            if (!Physics2D.Raycast(inputs.startPos, inputs.xAxis * Vector2.right, 1f, layer))
            {
                spriteRenderer.flipX = inputs.xAxis < 0;
                if (timer < moveData.lerpDuration)
                {
                    Debug.Log("GOGOOGOGO");
                    lerpPos = Vector2.Lerp(inputs.startPos, inputs.endPos, timer / moveData.lerpDuration);
                    movingObject.position = lerpPos;
                    timer += Time.deltaTime;

                }
                else
                {
                    anim.SetBool("isRunning", false);
                    timerInput -= Time.deltaTime;
                    timer = 0;
                    movingObject.position = inputs.endPos;
                    inputs.isLerping = false;
                }
            }

            else
            {
                anim.SetBool("isRunning", false);
                movingObject.position = inputs.startPos;
                timer = 0;
                inputs.isLerping = false;
            }


        }

        else if (inputs.yAxis != 0)
        {
            anim.SetBool("isRunning", true);
            inputs.isLerping = true;
            //Debug.DrawRay(movingObject.position, inputs.yAxis * Vector2.up, Color.black, 3f);

            inputs.endPos = inputs.startPos + inputs.yAxis * Vector2.up;
            Debug.DrawLine(inputs.startPos, inputs.endPos);
            if (!Physics2D.Raycast(inputs.startPos, inputs.yAxis * Vector2.up, 1f, layer))
            {
                if (timer < moveData.lerpDuration)
                {
                    lerpPos = Vector2.Lerp(inputs.startPos, inputs.endPos, timer / moveData.lerpDuration);
                    movingObject.position = lerpPos;
                    timer += Time.deltaTime;

                }

                else
                {
                    anim.SetBool("isRunning", false);
                    timerInput -= Time.deltaTime;
                    timer = 0;
                    movingObject.position = inputs.endPos;
                    inputs.isLerping = false;
                }
            }
            else
            {
                anim.SetBool("isRunning", false);
                movingObject.position = inputs.startPos;
                timer = 0;
                inputs.isLerping = false;
            }
        }

    }
}

