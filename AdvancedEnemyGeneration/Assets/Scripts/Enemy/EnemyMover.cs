using System;
using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;
    private bool _isCollided;

    public event Action Reached;

    public IEnumerator TravellingTime()
    {
        while (enabled)
        {
            if (_isCollided)
                break;

            Move();

            yield return null;
        }

        Reached?.Invoke();
    }

    public void SetIsCollided(bool value)
    {
        _isCollided = value;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Move()
    {
        transform.LookAt(_target);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
