using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour, HP
{
    public float serializedHP;
    public float hp { get; set; }

    private void Start()
    {
        hp = serializedHP;
    }
    public void TakeDamage(float dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
