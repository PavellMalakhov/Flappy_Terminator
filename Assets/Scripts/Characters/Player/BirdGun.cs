using System.Collections;
using UnityEngine;

public class BirdGun : Spawner<BirdMissile>
{
    [SerializeField] private InputReader _inputReader;

    private float _birdMissileLifeTime = 3f;

    private void FixedUpdate()
    {
        if (_inputReader.GetAttack())
        {
            _pool.Get();
        }
    }

    private IEnumerator BirdMissileLifeTime(float delay, BirdMissile birdMissile)
    {
        var wait = new WaitForSeconds(delay);

        yield return wait;

        _pool.Release(birdMissile);
    }

    protected override void Init(BirdMissile birdMissile)
    {
        birdMissile.transform.position = transform.position;
        birdMissile.transform.rotation = gameObject.transform.rotation;
        birdMissile.Go();
        StartCoroutine(BirdMissileLifeTime(_birdMissileLifeTime, birdMissile));
    }
}
