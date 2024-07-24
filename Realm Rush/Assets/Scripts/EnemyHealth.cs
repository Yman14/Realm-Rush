using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    
    int currentHitPoint;

    void OnEnable()
    {
        currentHitPoint = maxHitPoint;
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
            transform.parent.gameObject.SetActive(false);
        }
    }
}
