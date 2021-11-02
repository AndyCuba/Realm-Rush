using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    [SerializeField] float attackRange = 20f;
    [SerializeField] ParticleSystem projectileParticle;
    public Waypoint baseWaypoint; // what the tower is standing on
    // State
    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
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

    private void SetTargetEnemy()
    {
        EnemyDamage[] sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) return;

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;

    }

    private void CheckForEnemy()
    {
        Vector3 enemyPos = targetEnemy.transform.position;

        float distanceToEnemy = Vector3.Distance(enemyPos, transform.position);
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

    private Transform GetClosestEnemy(Transform transformA, Transform transformB)
    {
        float distanceToEnemyA = Vector3.Distance(transformA.position, transform.position);
        float distanceToEnemyB = Vector3.Distance(transformB.position, transform.position);

        return distanceToEnemyA < distanceToEnemyB ? transformA : transformB;
    }
}
