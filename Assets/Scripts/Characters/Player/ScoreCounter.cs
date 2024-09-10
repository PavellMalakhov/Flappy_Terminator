using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    private int _value;

    public event Action<int> Score—hanged;

    public void Reset()
    {
        _value = 0;

        Score—hanged?.Invoke(_value);
    }

    public void Add()
    {
        _value++;

        Score—hanged?.Invoke(_value);
    }
}
