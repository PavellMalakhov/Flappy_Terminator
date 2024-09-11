using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private ScoreCounter _counter;

    private void OnEnable()
    {
        _counter.Changed += Show;
    }

    private void OnDisable()
    {
        _counter.Changed -= Show;
    }

    private void Show(int score)
    {
        _text.text = ($"{score}");
    }

}
