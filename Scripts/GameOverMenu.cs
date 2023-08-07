using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameoverMenu;
    
    private void Update()
    {
        if (Health.isDead)
        {
            gameoverMenu.SetActive(true);
        }
    }
}
