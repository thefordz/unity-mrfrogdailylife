using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollect : MonoBehaviour
{
    [SerializeField] private int scoreValue;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<GameController>().CollectDiamond(scoreValue);
            Destroy(this.gameObject);
            SoundManage.instance.Play(SoundManage.SoundName.Collect);
        }
    }
}
