using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavGame.Core;

[RequireComponent(typeof(NavMeshAgent))]

public class playercontroller : TouchableGameObject
{
   NavMeshAgent agent;
   Camera cam;
   public LayerMask walkablelayer;
   
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

   
   
    void Update()
    {
       if (Input.GetMouseButtonDown(1)) 
       {
           Ray ray = cam.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;

           if(Physics.Raycast(ray, out hit, Mathf.Infinity,walkablelayer))
           {
               agent.SetDestination(hit.point);

           }


       }
    }
}
