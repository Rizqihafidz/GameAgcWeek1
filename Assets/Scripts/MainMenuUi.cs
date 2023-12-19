using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUi : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button creditsButton;


    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        creditsButton.onClick.AddListener(SeeCredits);

    }
    private void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void SeeCredits()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
