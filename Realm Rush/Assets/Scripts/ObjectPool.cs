using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float enemySpawnTime = 1f;
    [SerializeField] int enemyNum = 10;   
    
    void Start()
    {
        StartCoroutine(InstantiateEnemy());
    }


    IEnumerator InstantiateEnemy()
    {
        while(true)
        {
            Instantiate(enemyPrefab, transform);
            yield return new WaitForSeconds(enemySpawnTime);
        }
    }
}
