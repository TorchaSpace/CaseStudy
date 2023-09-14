using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour
{
    public Action OnRestartButtonClicked { get; set; }

    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject gameOverScreen;

    private void OnEnable()
    {
        restartButton.onClick.AddListener(OnRestartButton);
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(OnRestartButton);
    }

    private void OnRestartButton()
    {
        CloseGameOverScreen();
        OnRestartButtonClicked?.Invoke();
    }

    private void CloseGameOverScreen()
    {
        SceneManager.LoadScene(0);
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
