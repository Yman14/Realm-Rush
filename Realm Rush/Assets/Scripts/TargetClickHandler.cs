using System;
using UnityEngine;

[RequireComponent(typeof(Tile))]
public class TargetClickHandler : MonoBehaviour
{
    public LayerMask targetLayerMask;  // Set this in the Inspector to include only the layer of your target GameObject

    Tile waypoint;
    Bank bank;
    int cost = 75;

    void Start ()
    {
        waypoint = GetComponent<Tile>();
        bank = FindObjectOfType<Bank>();
    }

    void Update()
    {
        ProcessSpawnTower();
    }

    void ProcessSpawnTower()
    {
        if(bank == null)
        {
            return;
        }
        if(bank.CurrentBalance >= cost)
        {
            SpawnTower();
        }
    }

    public void SpawnTower()
    {
        if (Input.GetMouseButtonDown(0))  // 0 is the left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayerMask))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if(waypoint.SpawnTower())
                    {
                        bank.Withdraw(cost);
                    }
                }
            }
        }
        
    }
}