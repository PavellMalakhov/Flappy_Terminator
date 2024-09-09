using UnityEngine;
using System.Collections.Generic;

public class Gun : Spawner<Missile>
{
    [SerializeField] private float _heightGun;
    [SerializeField] private EnemyGenerator _enemyGenerator;

    private Queue<Vector2> _positionEnemy = new();

    private void OnEnable()
    {
        _enemyGenerator.Shot += Fire;
    }

    private void OnDisable()
    {
        _enemyGenerator.Shot += Fire;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Missile>(out Missile missile))
        {
            if (missile.Gun == this)
            {
                Release(missile);
            }
        }
    }

    protected override void Init(Missile missile)
    {
        Vector2 position = _positionEnemy.Dequeue();

        missile.transform.position = new Vector2(position.x, position.y + _heightGun);

        missile.Go();
    }

    private void Fire(Vector2 positionEnemy)
    {
        _positionEnemy.Enqueue(positionEnemy);

        Pool.Get(out Missile missile);

        missile.SetGunMissile(this);
    }
}
