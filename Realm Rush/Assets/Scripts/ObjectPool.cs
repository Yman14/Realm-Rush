using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float enemySpawnTime = 1f;
    [SerializeField] int poolSize = 5;
    public int PoolSize{ get { return poolSize; } }

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }
    
    void Start()
    {
        StartCoroutine(InstantiateEnemy());
    }

    void PopulatePool()
    {
        //fill the array with enemy object and set it to not active state
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator InstantiateEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(enemySpawnTime);
        }
    }

    private void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
