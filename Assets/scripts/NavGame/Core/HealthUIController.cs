using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


namespace NavGame.Core
{
    [RequireComponent(typeof(DamageableGameObject))]
    public class HealthUIController : MonoBehaviour
    {
        public GameObject healthUIPrefab;

        public Transform healthPosition;

        GameObject healthUI;
        Transform cam;

        DamageableGameObject damageable;

        Image healthSlider;


        void Awake()
        {
            Canvas canvas = FindWorldCanvas();
            if (canvas == null)
            {
                throw new Exception("a WorldSpace canvas was neded");
            }
            cam = Camera.main.transform;
            healthUI = Instantiate(healthUIPrefab, canvas.transform);
        }
        void LateUpdate()
        {
            if (healthUI != null)
            {
                healthUI.transform.position = healthPosition.position;
                healthUI.transform.forward = -cam.forward;
                healthSlider = healthUI.transform.GetChild(0).GetComponent<Image>();
                damageable = GetComponent<DamageableGameObject>();

                damageable.onHealthChanged += UpdateHealth;
                damageable.onDied += DestroyHealth;

            }
        }

        Canvas FindWorldCanvas()
        {
            foreach (Canvas c in FindObjectsOfType<Canvas>())
            {
                if (c.renderMode == RenderMode.WorldSpace)
                {
                    return c;
                }
            }
            return null;

        }

        void UpdateHealth(int maxHealth, int currentHealth)
        {
            if (healthUI != null)
            {
                float healthPercent = (float)currentHealth / maxHealth;
                healthSlider.fillAmount = healthPercent;
            }

        }
        void DestroyHealth()
        {
            Destroy(healthUI);
        }
    }
}