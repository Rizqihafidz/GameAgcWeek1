using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditUi : MonoBehaviour
{
    public Button menuButton;
    private void Start()
    {
        menuButton.onClick.AddListener(BackToMenu);
    }
    private void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
