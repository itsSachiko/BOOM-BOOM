using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveData", menuName = "Scriptable/MoveData")]
public class MoveData : ScriptableObject
{
    public bool isAI;
    public float lerpDuration;
    public LayerMask layer;
    public float cooldownDuration;
}
