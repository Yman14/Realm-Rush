using UnityEngine;

public class TargetClickHandler : MonoBehaviour
{
    public LayerMask targetLayerMask;  // Set this in the Inspector to include only the layer of your target GameObject

    Waypoint waypoint;

    void Start ()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SpawnTower();
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
                    waypoint.SpawnTower();
                }
            }
        }
        
    }
}