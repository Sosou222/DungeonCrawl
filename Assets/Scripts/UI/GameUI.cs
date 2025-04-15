using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverHolder;
    [SerializeField] private GameObject nextLevelHolder;

    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button quitButton2;
    void Start()
    {
        retryButton.onClick.AddListener(RestartLevel);
        quitButton.onClick.AddListener(GoBackToMainMenu);
        quitButton2.onClick.AddListener(GoBackToMainMenu);
        nextLevelButton.onClick.AddListener(GoNextLevel);
    }

    public void ShowGameOverScreen()
    {
        gameOverHolder.SetActive(true);
    }

    public void ShowNextLevelScreen()
    {
        nextLevelHolder.SetActive(true);
    }

    private void GoNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
