using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> Score—hanged;

    public void Reset()
    {
        _score = 0;

        Score—hanged?.Invoke(_score);
    }

    public void Add()
    {
        _score++;

        Score—hanged?.Invoke(_score);
    }
}
