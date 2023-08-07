using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    public static bool isHowto = false;

    [SerializeField] private GameObject howtoMenu;

    private void Update()
    {
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            howtoMenu.SetActive(true);
            isHowto = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            howtoMenu.SetActive(false);
            isHowto = false;
        }
    }
    
}
