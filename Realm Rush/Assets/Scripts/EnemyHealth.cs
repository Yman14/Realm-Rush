using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    
    int currentHitPoint;

    EnemyScript enemy;

    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
        gameObject.tag = "Enemy"; 
    }

    void Start()
    {
        enemy = GetComponentInParent<EnemyScript>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        ProcessKill();
    }

    void ProcessHit()
    {
        currentHitPoint--;
    }

    void ProcessKill()
    {
        if (currentHitPoint <= 0)
        {
            enemy.RewardGold();
            gameObject.tag = "DeadEnemy";   //change tag if dead
            transform.parent.gameObject.SetActive(false);
        }
    }
}
