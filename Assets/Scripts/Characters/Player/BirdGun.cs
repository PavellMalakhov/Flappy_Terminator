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
            Pool.Get();
        }
    }

    protected override void Init(BirdMissile birdMissile)
    {
        birdMissile.transform.position = transform.position;
        birdMissile.transform.rotation = gameObject.transform.rotation;
        birdMissile.SetGunMissile(this);
        birdMissile.Go();
        StartCoroutine(CountingLifeTime(_birdMissileLifeTime, birdMissile));
    }

    private IEnumerator CountingLifeTime(float delay, BirdMissile birdMissile)
    {
        var wait = new WaitForSeconds(delay);

        yield return wait;

        Release(birdMissile);
    }
}
