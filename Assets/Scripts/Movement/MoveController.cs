using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] MoveData moveData;
    InputsComponent inputs;
    MovementComponent movementComponent;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform bombPrefab;
    void Start()
    {
        inputs = moveData.isAI ? new EnemyInput() : new PlayerInputs();
        movementComponent = new MovementComponent(inputs,moveData,transform, anim, spriteRenderer);
    }

   
    void Update()
    {
        inputs.Movement();
        movementComponent.Tick();
        inputs.BombPlacing();
        if (inputs.bombPlaced)
        {
            inputs.bombPlaced = false;
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }
    }
}
