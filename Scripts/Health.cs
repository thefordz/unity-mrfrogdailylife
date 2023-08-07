using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float CurrentHealth { get; private set; }
    private Animator anim;
    public static bool isDead = false;

    private void Awake()
    {
        CurrentHealth = startingHealth;
        anim = GetComponent<Animator>();
        isDead = false;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, startingHealth);

        if (CurrentHealth>0)
        {
            anim.SetTrigger("hurt");
            SoundManage.instance.Play(SoundManage.SoundName.Hurt);
            
        }
        else
        {
            if (!isDead)
            {
                GetComponent<PlayerMovement>().enabled = false;
                isDead = true;
                Time.timeScale = 0;
            }
            
        }
    }

    public void AddHealth(float value)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, startingHealth);
    }
}
