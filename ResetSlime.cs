using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSlime : MonoBehaviour
{

    public LivesManager livesManager;
    public MouseManager mouseManager;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(NextRound), 3);
        }
    }

    private void NextRound()
    {
        mouseManager.ResetSlime();
        livesManager.LoseLife();
    }
}
