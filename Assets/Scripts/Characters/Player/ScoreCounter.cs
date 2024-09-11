using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    private int _value;

    public event Action<int> Changed;

    public void Reset()
    {
        _value = 0;

        Changed?.Invoke(_value);
    }

    public void Add()
    {
        _value++;

        Changed?.Invoke(_value);
    }
}
