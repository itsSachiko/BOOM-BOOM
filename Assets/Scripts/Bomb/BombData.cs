using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BombData", menuName = "ScriptableObject/ScriptData")]
public class BombData : ScriptableObject
{
    public float timeToExplode;
    public float rangeX;
    public float rangeY;
    public float dmg;
}
