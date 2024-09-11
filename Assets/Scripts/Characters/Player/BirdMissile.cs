using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMissile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 30f;

    public void Go()
    {
        _rigidbody2D.velocity = transform.right * _speed;
    }
}
