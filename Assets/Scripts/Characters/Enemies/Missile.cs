using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Missile : MonoBehaviour, IInteractable
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 10f;

    public void Go()
    {
        _rigidbody2D.velocity = new Vector2(- _speed, 0f);
    }
}
