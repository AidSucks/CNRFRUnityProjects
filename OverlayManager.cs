using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverlayManager : MonoBehaviour
{
    private Canvas UICanvas;
    private TextMeshProUGUI gameOverText;
    private Button playAgainButton;

    [Header("Lives")]
    public LivesManager livesManager;
    public GameObject heartObj;
    public float UIOffset;

    private Stack<GameObject> hearts;

    public bool isGameOver;

    public void Start()
    {
        isGameOver = false;

        UICanvas = GetComponent<Canvas>();
        gameOverText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        playAgainButton = transform.GetChild(1).GetComponent<Button>();

        gameOverText.SetText("");
        gameOverText.enabled = false;

        playAgainButton.gameObject.SetActive(false);

        InitializeUILives();
    }

    private void InitializeUILives()
    {
        hearts = new Stack<GameObject>();

        int lives = livesManager.lives;

        for (int i = 0; i < lives; i++)
        {
            GameObject heart = Instantiate(heartObj);

            heart.transform.localPosition = i * UIOffset * Vector3.right;

            heart.transform.SetParent(UICanvas.transform, false);

            hearts.Push(heart);
        }
    }

    public void RemoveLife()
    {
        if (isGameOver) return;

        GameObject heart = hearts.Pop();
        Destroy(heart);
    }

    public void AddLife()
    {
        if (isGameOver) return;

        GameObject heart = Instantiate(heartObj);

        heart.transform.localPosition = hearts.Count * UIOffset * Vector3.right;

        heart.transform.SetParent(UICanvas.transform, false);

        hearts.Push(heart);

        livesManager.lives++;
    }

    public void GameOver(string msg)
    {
        if (isGameOver) return;

        gameOverText.SetText(msg);
        gameOverText.enabled = true;
        playAgainButton.gameObject.SetActive(true);
        isGameOver = true;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
