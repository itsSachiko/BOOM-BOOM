using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour, HP
{
    public float serializedHP;
    public float hp { get; set; }

    private void Start()
    {
        hp = serializedHP;
    }
    public void TakeDamage(float dmg)
    {
        Debug.LogWarning("i ook dmg");
        hp -= dmg;
        if (hp <= 0)
        {
            //u lost

        }
    }

}
