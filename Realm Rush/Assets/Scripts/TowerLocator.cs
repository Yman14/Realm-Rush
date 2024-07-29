using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] GameObject bullet;

    List<GameObject> target = new List<GameObject>();

    GameObject currentTarget;
    bool targetLocked;


    void Start()
    {
        //bug - if theres no target, you cant place tower
        //and if the target died it will just keep shooting at the place
        //where the target was destroyed. very bad code
        //target = FindObjectOfType<EnemyMover>().transform;


        currentTarget = null;
        targetLocked = false;
    }

    void Update()
    {
        targetIsActive();
        AimWeapon();
        LockingTarget();
        if(currentTarget)
        {
            if(currentTarget.CompareTag("DeadEnemy"))
            {
                target.Remove(currentTarget);
                currentTarget = null;
                targetLocked = false;
            }
        }
    }

    void LockingTarget()
    {
        if(!targetLocked && target != null)
        {
            foreach(GameObject i in target)
            {
                if(i != null)
                {
                    currentTarget = i;
                    targetLocked = true;
                    break;
                }
            }
        }
    }

    private void AimWeapon()
    {
        if(currentTarget != null)
        {
            weapon.LookAt(currentTarget.transform);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            target.Add(other.gameObject);      
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            target.Remove(other.gameObject);

            if(other.gameObject == currentTarget)
            {
                currentTarget = null;
                targetLocked = false;
            }
        }
    }


    void targetIsActive()
    {
        if (currentTarget == null)
        {
            bullet.SetActive(false);
        }
        else{
            bullet.SetActive(true);
        }
    }

    


}
