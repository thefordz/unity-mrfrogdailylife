using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTextMeshPro;
    [SerializeField] private int startingScore;
    [SerializeField] private GameObject cup;
    public int CurrentScore { get; private set; }

    private void Awake()
    {
        CurrentScore = startingScore;
        
    }
    

    public void CollectDiamond(int score)
    {
        CurrentScore += score;
        scoreTextMeshPro.text = "Diamond : " + CurrentScore + " /25";

        if (CurrentScore <= 0)
        {
            CurrentScore = 0;
        }
        else if(CurrentScore >= 25)
        {
            scoreTextMeshPro.text = "Complete";
            cup.gameObject.SetActive(true);
        }
    }
    
    
}
