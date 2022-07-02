using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBotBar : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private float myltiply;


    public void SetBar(float health)
    {
        healthBar.transform.localScale = new Vector3(health / myltiply, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void DestroyBar()
    {
        Destroy(healthBar);
        Destroy(this);
    }
}
