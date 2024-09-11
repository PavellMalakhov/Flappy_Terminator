using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 1f;

    public event Action<Enemy> Destroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<BirdMissile>(out BirdMissile birdMissile))
        {
            Destroyed?.Invoke(this);

            birdMissile.gameObject.SetActive(false);
        }
    }

    public void Go()
    {
        _rigidbody2D.velocity = new Vector2(- _speed, 0f);
    }
}
