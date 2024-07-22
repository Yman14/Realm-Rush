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
        //bug - if theres no target, you cant place tower
        //and if the target died it will just keep shooting at the place
        //where the target was destroyed. very bad code
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
