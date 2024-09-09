using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _score;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _scoreCounter.Score—hanged += Show;
    }

    private void OnDisable()
    {
        _scoreCounter.Score—hanged -= Show;
    }

    private void Show(int score)
    {
        _score.text = ($"{score}");
    }

}
