using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObj : MonoBehaviour
{
    [SerializeField] private float damage;
    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Health>().TakeDamage(damage);
        }

        else if (col.tag == "Skill")
        {
            Destroy(col.gameObject);
        }
    }
}
