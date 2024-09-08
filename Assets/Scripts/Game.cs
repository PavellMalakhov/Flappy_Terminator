using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private Bird _bird;

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;
        _bird.GameOver += _endScreen.Open;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bird.GameOver -= _endScreen.Open;
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;

        _bird.Reset();
    }
}
