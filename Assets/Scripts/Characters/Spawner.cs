using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapaciti = 95;
    [SerializeField] private int _poolMaxSize = 100;

    private protected ObjectPool<T> Pool;

    protected virtual void Awake()
    {
        Pool = new ObjectPool<T>(
        createFunc: () => Instantiate(_prefab),
        actionOnGet: (obj) => SetActive(obj),
        actionOnRelease: (obj) => obj.gameObject.SetActive(false),
        actionOnDestroy: (obj) => Destroy(obj),
        collectionCheck: true,
        defaultCapacity: _poolCapaciti,
        maxSize: _poolMaxSize);
    }

    public virtual void Release(T obj)
    {
        Pool.Release(obj);
    }

    protected virtual void SetActive(T obj)
    {
        obj.gameObject.SetActive(true);

        Init(obj);
    }

    protected virtual void Init(T obj) { }
}
