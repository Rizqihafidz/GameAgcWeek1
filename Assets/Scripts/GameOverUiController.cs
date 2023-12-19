using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUiController : MonoBehaviour
{
    public Button menuButton;
    public Button retryButton;
    private void Start()
    {
        menuButton.onClick.AddListener(BackToMenu);
        retryButton.onClick.AddListener(Retry);
    }
    private void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }
}
