using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour, HP
{
    public float serializedHP;
    [HideInInspector] public GameManager manager;
    public float hp { get; set; }

    private void Start()
    {
        hp = serializedHP;
        manager = FindObjectOfType<GameManager>();
    }

    private void OnEnemyDeath()
    {
        manager.onEnemyDeath?.Invoke();
        Destroy(gameObject);
    }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            OnEnemyDeath();
        }
    }
}
