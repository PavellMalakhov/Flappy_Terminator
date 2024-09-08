using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 1f;

    public EnemyGenerator EnemyGenerator { get; private set; }

    public void Go()
    {
        _rigidbody2D.velocity = new Vector2(- _speed, 0f);
    }

    public void SetSpawnerEnemy(EnemyGenerator enemyGenerator)
    {
        EnemyGenerator = enemyGenerator;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<BirdMissile>(out _))
        {
            EnemyGenerator.Release(this);
        }
    }
}
