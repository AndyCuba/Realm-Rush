using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 20f;
    [SerializeField] ParticleSystem projectileParticle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            objectToMove.LookAt(targetEnemy);
            CheckForEnemy();
        }
        else
        {
            FireAtEnemy(false);
        }
    }

    private void CheckForEnemy()
    {
        Vector3 enemyPos = targetEnemy.transform.position;
        Vector3 towerPos = gameObject.transform.position;

        float distanceToEnemy = Vector3.Distance(enemyPos, towerPos);

        if (distanceToEnemy <= attackRange)
        {
            FireAtEnemy(true);
        }
        else
        {
            FireAtEnemy(false);
        }
    }

    private void FireAtEnemy(bool isActive)
    {
        var emissionModule = projectileParticle.emission;

        emissionModule.enabled = isActive;
    }
}
