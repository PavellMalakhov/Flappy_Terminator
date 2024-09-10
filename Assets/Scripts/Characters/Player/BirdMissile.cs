using UnityEngine;

public class BirdMissile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 30f;

    private BirdGun _birdGun;

    public void Go()
    {
        _rigidbody2D.velocity = transform.right * _speed;
    }

    public void SetGunMissile(BirdGun birdGun)
    {
        _birdGun = birdGun;
    }
}
