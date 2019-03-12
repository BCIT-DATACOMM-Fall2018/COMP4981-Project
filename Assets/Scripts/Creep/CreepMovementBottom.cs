﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreepMovementBottom : MonoBehaviour
{
    GameObject towerBottom1;
    GameObject towerBottom2;

    Transform enemyBase;
    NavMeshAgent nav;

    //Tags of towers and enemy base
    private readonly string towerBottom1Tag = "Tower-Bottom-1";
    private readonly string towerBottom2Tag = "Tower-Bottom-2";

    private readonly string enemyBaseTag = "Enemy-Base";

    void Awake()
    {
        if (GameObject.FindWithTag(towerBottom1Tag) != null)
            towerBottom1 = GameObject.FindGameObjectWithTag(towerBottom1Tag);

        if (GameObject.FindWithTag(towerBottom2Tag) != null)
            towerBottom2 = GameObject.FindGameObjectWithTag(towerBottom2Tag);

        enemyBase = GameObject.FindGameObjectWithTag(enemyBaseTag).transform;

        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (GameObject.FindWithTag(towerBottom1Tag) != null)
            nav.SetDestination(towerBottom1.transform.position);
        else if (GameObject.FindWithTag(towerBottom2Tag) != null)
            nav.SetDestination(towerBottom2.transform.position);
        else
            nav.SetDestination(enemyBase.position);
    }

    // Unity calls OnTriggerEnter when an object first touches a trigger collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyBaseTag)) //If reach the enemy base, destroy self
            Destroy(this.gameObject);
        else
        {
            TowerManager towerManagerScript = other.GetComponent<TowerManager>();
            towerManagerScript.health -= 5;
        }
    }
}