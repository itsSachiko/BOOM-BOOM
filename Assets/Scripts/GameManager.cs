using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<EnemyStats> enemies = new();
    int enemiesAtStart;
    public Action onEnemyDeath;
    public static Action onWin;
    
    private void Start()
    {
        
        enemies = FindObjectsOfType<EnemyStats>().ToList();

        enemiesAtStart = enemies.Count;
    }


    void OnEnemyDeath()
    {
        enemiesAtStart--;

        if (enemiesAtStart == 0)
        {
            onWin?.Invoke();
        }
    }

    private void OnEnable()
    {
        onEnemyDeath += OnEnemyDeath; 
    }

   
}
