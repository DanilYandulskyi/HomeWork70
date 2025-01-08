using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private float _initialSpeed;
    private Transform _transform;
    
    private void Awake()
    {
        _transform = transform;
        _initialSpeed = _speed;
    }

    public void Move(Vector3 direction)
    {
        _speed = _initialSpeed;
        Vector3 offset = direction.normalized * (_speed * Time.deltaTime);

        _transform.Translate(offset);
    }

    public void Stop()
    {
        _speed = 0;
    }
}
