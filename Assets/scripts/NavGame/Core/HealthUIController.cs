using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace NavGame.Core
{
    [RequireComponent(typeof(DamageableGameObject))]
    public class HealthUIController : MonoBehaviour
    {
        public GameObject healthUIPrefab;

        public Transform healthPosition;

        GameObject healthUI;
        Transform cam;

        void Awake()
        {
            Canvas canvas = FindWorldCanvas();
            if(canvas == null)
            {
                throw new Exception("a WorldSpace canvas was neded"); 
            }
            cam = Camera.main.transform;
            healthUI = Instantiate(healthUIPrefab, canvas.transform);
        }
        void LateUpdate()
        {
            if(healthUI != null)
            {
                healthUI.transform.position = healthPosition.position;
                healthUI.transform.forward =  -cam.forward;
            }
        }

        Canvas FindWorldCanvas()
        {
            foreach (Canvas c in FindObjectsOfType<Canvas>())
            {
                if(c. renderMode == RenderMode.WorldSpace)
                {
                    return c;
                }
            }
            return null;

        }



    }
}
//