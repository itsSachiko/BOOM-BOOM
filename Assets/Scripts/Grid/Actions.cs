using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Actions", menuName = "ScriptableObject/Actions")]
public class Actions : ScriptableObject
{
    public Action onActivation; 

    [HideInInspector] public List<Collider2D> colliders;

    private void OnEnable()
    {
        colliders = new ();
    }
}
