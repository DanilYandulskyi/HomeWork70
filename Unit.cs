using UnityEngine;
using System;

[RequireComponent(typeof(Mover))]
public class Unit : MonoBehaviour
{
    private const float DistanceToStop = 0.2f;
    
    [SerializeField] private Gold _resource;
    [SerializeField] private Vector3 _initialPosition;
    [SerializeField] private Vector3 _moveDirection;

    private Mover _movement;

    public event Action<Gold> CollectedResource;

    public bool IsResourceCollected { get; private set; } = false;
    public bool IsStanding { get; private set; } = true;

    private void Awake()
    {
        _movement = GetComponent<Mover>();
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if (_resource != null)
        {
            _movement.Move(_moveDirection);
            IsStanding = false;
        }

        if (IsResourceCollected & Vector2.SqrMagnitude(transform.position - _initialPosition) <= DistanceToStop)
        {
            OnCollectedResourse(ref _resource);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Gold resource))
        {
            if (resource == _resource)
            {
                IsResourceCollected = true;
                ChangeMoveDirection();
                resource.StartFollow(transform);
            }
        }
    }

    public void StartMovingToResource(Gold resource)
    {
        _resource = resource;
        _moveDirection = _resource.transform.position - transform.position;
    }

    private void ChangeMoveDirection()
    {
        _moveDirection = _initialPosition - transform.position;
    }

    private void OnCollectedResourse(ref Gold resource)
    {
        CollectedResource?.Invoke(resource);
        _movement.Stop();
        IsResourceCollected = false;
        IsStanding = true;
        resource.StopFollow();
        resource.Disable();
        resource = null;
    }
}
