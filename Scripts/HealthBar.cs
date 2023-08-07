using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhelathBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhelathBar.fillAmount = playerHealth.CurrentHealth / 10;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.CurrentHealth / 10;
    }
}
