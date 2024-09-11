using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private InputReader _inputReader;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;

        _rigidbody = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        _rigidbody.velocity = new Vector2(_speed, 0);
    }

    private void FixedUpdate()
    {
        if (_inputReader.GetTakeOff())
        {
            _rigidbody.velocity = new Vector2(_speed, _tapForce);

            StartCoroutine(UpwardsBird());
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _rigidbody.velocity = Vector2.zero;
    }

    private IEnumerator UpwardsBird()
    {
        var wait = new WaitForEndOfFrame();

        float _upwardsTime = 0;

        while (transform.rotation.eulerAngles.z <= _maxRotation.eulerAngles.z - 1f || transform.rotation.eulerAngles.z > 300f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _maxRotation, _upwardsTime);

            _upwardsTime += Time.deltaTime;

            yield return wait;
        }
    }
}
