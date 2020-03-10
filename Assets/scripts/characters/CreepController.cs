using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavGame.Core;

[RequireComponent(typeof(NavMeshAgent))]
public class CreepController : CombatGameObject
{
    NavMeshAgent agent;
    GameObject finalTarget;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject obj = GameObject.FindWithTag("Finish");
        if(obj != null)
        {
            finalTarget = obj;
        }

    }

    void Start()
    {
        if(finalTarget != null){
            agent.SetDestination(finalTarget.transform.position);
        }
    }
}
