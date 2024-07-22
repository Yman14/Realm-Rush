using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable{    get { return isPlaceable; }}

    [SerializeField] GameObject towerPrefab;
    
    [Tooltip("Towers spawn at runtime will be place here.")]GameObject towerPlacement;


    void Start()
    {
        towerPlacement = GameObject.FindWithTag("SpawnAtRuntime");
    }

    void OnMouseDown()
    {
        if(isPlaceable)
        {
            GameObject towersSpawnAtRuntime = Instantiate(towerPrefab, transform.position, Quaternion.identity);
            
            //spawn tower will be placed in towerPlacement game object
            towersSpawnAtRuntime.transform.parent = towerPlacement.transform;

            Debug.Log(transform.name);
            isPlaceable = false;
        }
    }
}
