using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] MoveData moveData;
    InputsComponent inputs;
    MovementComponent movementComponent;
    [SerializeField] Animator anim;
    void Start()
    {
        inputs = moveData.isAI ? new EnemyInput() : new PlayerInputs();
        movementComponent = new MovementComponent(inputs,moveData,transform, anim);
    }

   
    void Update()
    {
        inputs.Movement();
        movementComponent.Tick();

    }
}
