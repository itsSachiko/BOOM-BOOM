using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChecker : MonoBehaviour
{
    [SerializeField] Actions onTrigger;
    private bool hasPlayer, hasWall, hasIndestrucruble;
    private void Start()
    {
        
    }

    Collider2D[] whatDoIHave()
    {
        Collider2D[] coll = Physics2D.OverlapBoxAll(transform.position, Vector2.one, 0);
        if (coll != null)
        {
            onTrigger.colliders.AddRange(coll);
            return coll;
        }

        else 
        { 
            return null; 
        }

    }
}
