using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _stopDistance = 2;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = _player.position - transform.position;

        if (direction.magnitude > _stopDistance)
        {
            Vector3 move = direction.normalized * _speed * Time.deltaTime;
            _rigidbody.MovePosition(transform.position + move);
        }
    }
}
