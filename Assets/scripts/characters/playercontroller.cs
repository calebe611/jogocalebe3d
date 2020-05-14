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

   public GameObject prefab;
   
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;

       GameObject obj = GameObject.FindWithTag("Finish");
       DamageableGameObject dgo = obj.GetComponent<DamageableGameObject>();
       GameObject projectile = Instantiate( prefab, transform.position, Quaternion.identity) as GameObject;
       ProgectileController controller = projectile.GetComponent<ProgectileController>();
       controller.Init(dgo);
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
