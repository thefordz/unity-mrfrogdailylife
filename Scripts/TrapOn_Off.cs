using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapOn_Off : MonoBehaviour
{
    [SerializeField] private GameObject trap;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag=="Skill")
        {
            trap.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag=="Skill")
        {
            trap.gameObject.SetActive(false);
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" || col.tag=="Skill")
        {
            trap.gameObject.SetActive(true);
        }
    }
    

}
