using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshPro _poolInfo;

    private int _score;

    public void Reset()
    {
        _score = 0;
    }

    public void Add()
    {
        _score++;

        _poolInfo.text = ($"{_score}");
    }
}
