using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{

    public int lives;

    public OverlayManager overlayManager;

    public void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(lives <= 0)
        {
            overlayManager.GameOver("Game Over!");
        }
    }
    public void LoseLife()
    {
        if (overlayManager.isGameOver) return;

        overlayManager.RemoveLife();
        lives -= 1;
    }
}
