using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private CounterUI _counter;
    [SerializeField] private bool _isCanLaunch = false;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.isKinematic = true;
    }

    private void Update()
    {
        if (_isCanLaunch)
        {
            transform.position = _shootPoint.position;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpeedChange(_speed);
        }
    }

    public void SetCounter(CounterUI count)
    {
        _counter = count;
    }

    public void SetPoint(Transform shootPoint, Transform startPoint)
    {
        _shootPoint = shootPoint;
        transform.DOJump(shootPoint.position, 1, 1, 1).OnComplete(() =>
        {
            _isCanLaunch = true;
        });
    }

    public void Launch(Vector2 direction)
    {
        _isCanLaunch = false;
        _rigidBody.isKinematic = false;
        _rigidBody.AddForce(direction, ForceMode2D.Impulse);
    }

    public void SpeedChange(float speed)
    {
        _rigidBody.AddForce(_rigidBody.velocity * speed, ForceMode2D.Impulse);;
    }
}