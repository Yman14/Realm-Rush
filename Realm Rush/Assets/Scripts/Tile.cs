using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable{    get { return isPlaceable; }}

    [SerializeField] GameObject towerPrefab;
    [SerializeField] GameObject PlaceableMark;
    
    [Tooltip("Towers spawn at runtime will be place here.")]GameObject towerPlacement;

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }


    void Start()
    {
        towerPlacement = GameObject.FindWithTag("SpawnAtRuntime");

        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            
            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void Update()
    {
        ShowPlaceableTile();
    }

    void ShowPlaceableTile()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if(isPlaceable)
            {
                //toggle
                PlaceableMark.SetActive(!PlaceableMark.activeSelf);
            }
        }
    }

    //void OnMouseDown()
    public bool SpawnTower()
    {
        if(isPlaceable)
        {
            if(Instantiate(towerPrefab, transform.position, Quaternion.identity))
            {
                //spawn tower will be placed in towerPlacement game object
               // towersSpawnAtRuntime.transform.parent = towerPlacement.transform;

                Debug.Log(transform.name);
                isPlaceable = false;
                PlaceableMark.SetActive(!PlaceableMark.activeSelf);
                return true;
            }
            
            
        }
        return false;
    }
}
