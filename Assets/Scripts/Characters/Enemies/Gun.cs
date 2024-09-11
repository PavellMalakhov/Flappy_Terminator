using UnityEngine;
using System.Collections.Generic;

public class Gun : Spawner<Missile>
{
    [SerializeField] private float _heightGun;
    [SerializeField] private EnemyGenerator _enemyGenerator;

    private Queue<Vector2> _positionEnemy = new();
    private List<Missile> _activeMissile = new();

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
            if (_activeMissile.Contains(missile))
            {
                Release(missile);
            }
        }
    }

    protected override void Init(Missile missile)
    {
        _activeMissile.Add(missile);

        Vector2 position = _positionEnemy.Dequeue();

        missile.transform.position = new Vector2(position.x, position.y + _heightGun);

        missile.Go();
    }

    private void Fire(Vector2 positionEnemy)
    {
        _positionEnemy.Enqueue(positionEnemy);

        GetGameObject();
    }

    protected override void Release(Missile missile)
    {
        _activeMissile.Remove(missile);

        base.Release(missile);
    }
}
