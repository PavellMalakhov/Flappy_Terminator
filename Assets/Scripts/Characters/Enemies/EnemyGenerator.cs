using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class EnemyGenerator : Spawner<Enemy>
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _xOffset = 20f;
    [SerializeField] private float _heightMin;
    [SerializeField] private float _heightMax;
    [SerializeField] private float _EnemyRepeatTime = 3.7f;
    [SerializeField] private float _rateFire = 2f;
    [SerializeField] private ScoreCounter _scoreCounter;

    private Dictionary<Enemy, Coroutine> _enemyCoroutine = new();

    public event Action<Vector2> Shot;

    private void Start()
    {
        StartCoroutine(RepeatGetEnemy(_EnemyRepeatTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (enemy.EnemyGenerator == this)
            {
                Release(enemy);
            }
        }
    }

    public override void Release(Enemy enemy)
    {
        StopCoroutine(_enemyCoroutine[enemy]);
        _enemyCoroutine.Remove(enemy);

        base.Release(enemy);

        _scoreCounter.Add();
    }

    protected override void Init(Enemy enemy)
    {
        Vector3 position = enemy.transform.position;
        position.x = _bird.transform.position.x + _xOffset;

        enemy.transform.position = new Vector2(position.x, UnityEngine.Random.Range(_heightMin, _heightMax));

        _enemyCoroutine.Add(enemy, StartCoroutine(OpenFire(_rateFire, enemy)));

        enemy.Go();
    }

    private IEnumerator RepeatGetEnemy(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return wait;

            GetGameObject();
        }
    }

    private void GetGameObject()
    {
        Pool.Get(out Enemy enemy);

        enemy.SetSpawnerEnemy(this);
    }

    private IEnumerator OpenFire(float rateFire, Enemy enemy)
    {
        var wait = new WaitForSeconds(rateFire);

        while (enemy.enabled)
        {
            yield return wait;

            Shot?.Invoke(enemy.transform.position);
        }
    }
}
