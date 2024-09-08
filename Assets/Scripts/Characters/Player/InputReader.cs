using UnityEngine;

public class InputReader : MonoBehaviour
{
    private bool _isAttack;
    private bool _isTakeOff;

    public float Direction { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isTakeOff = true;
        }
    }

    public bool GetAttack() => GetBoolAsTrigger(ref _isAttack);
    public bool GetTakeOff() => GetBoolAsTrigger(ref _isTakeOff);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
