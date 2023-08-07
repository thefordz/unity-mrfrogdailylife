using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextScene : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;


    private void OnTriggerEnter2D(Collider2D col)
    {
        // check if we are colliding with the player
        if (col.tag=="Player")
        {
            SoundManage.instance.Play(SoundManage.SoundName.Teleport);
            // load the next scene
            SceneManager.LoadScene(_nextSceneName);
        }
    }
}
