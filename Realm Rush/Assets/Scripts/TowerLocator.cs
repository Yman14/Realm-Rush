using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;

    Transform target;

    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
