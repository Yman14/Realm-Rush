using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startingCoordinates;
    [SerializeField] Vector2Int destinationCoordinates;

    Node startNode;
    Node destinationNode;
    Node currentSearchNode;


    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> pathTracked = new Dictionary<Vector2Int, Node>();


    Vector2Int[] directions = {Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();


    void Awake()
    {
        gridManager = GetComponent<GridManager>();
        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }

        startNode = new Node(startingCoordinates, true);
        destinationNode = new Node(destinationCoordinates, true);
    }

    void Start()
    {
        BreathSearchFirst();
    }

    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;
            if(grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);
            }

            foreach(Node neighbor in neighbors)
            {
                if(!pathTracked.ContainsKey(neighbor.coordinates) && neighbor.isWalkable == true)
                {
                    frontier.Enqueue(neighbor);
                    pathTracked.Add(neighbor.coordinates, neighbor);
                }
            }
        }
    }

    void BreathSearchFirst()
    {
        bool isRunning = true;

        frontier.Enqueue(startNode);
        pathTracked.Add(startNode.coordinates, startNode);

        while(frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            ExploreNeighbors();
            currentSearchNode.isExplored = true;

            if(currentSearchNode.coordinates == destinationNode.coordinates)
            {
                isRunning = false;
            }
        } 
    }
}
