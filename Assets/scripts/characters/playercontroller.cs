using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playercontroller : MonoBehaviour
{
   NavMeshAgent agent;
   Camera cam;
   public LayerMask walkablelayer;
   
    void Start()
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
