using UnityEngine;

public class InputReader : MonoBehaviour
{
    private bool _isAttack;
    private bool _isTakeOff;

    private int _mouseButtonAttack = 0;
    private KeyCode _takeOff = KeyCode.Space;

    public float Direction { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonAttack))
        {
            _isAttack = true;
        }

        if (Input.GetKeyDown(_takeOff))
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
