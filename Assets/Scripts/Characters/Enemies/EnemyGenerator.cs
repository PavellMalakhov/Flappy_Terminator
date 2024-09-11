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

    private Dictionary<Enemy, Coroutine> _enemyShotCoroutine = new();
    private List<Enemy> _activeEnemies = new();

    public event Action<Vector2> Shot;

    private void Start()
    {
        StartCoroutine(RepeatGetEnemy(_EnemyRepeatTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (_activeEnemies.Contains(enemy))
            {
                Release(enemy);
            }
        }
    }

    protected override void Release(Enemy enemy)
    {
        enemy.Destroyed -= Release;

        _activeEnemies.Remove(enemy);

        StopCoroutine(_enemyShotCoroutine[enemy]);
        _enemyShotCoroutine.Remove(enemy);

        base.Release(enemy);

        _scoreCounter.Add();
    }

    protected override void Init(Enemy enemy)
    {
        _activeEnemies.Add(enemy);

        enemy.Destroyed += Release;

        Vector3 position = enemy.transform.position;
        position.x = _bird.transform.position.x + _xOffset;

        enemy.transform.position = new Vector2(position.x, UnityEngine.Random.Range(_heightMin, _heightMax));

        _enemyShotCoroutine.Add(enemy, StartCoroutine(OpenFire(_rateFire, enemy)));

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
