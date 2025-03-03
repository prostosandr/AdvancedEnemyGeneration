using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private Painter _painter;
    [SerializeField] private bool _isCollided;

    private Coroutine _coroutine;

    public event Action<Enemy> Deactivated;

    private void OnEnable()
    {
        _enemyMover.Reached += Deactivate;
    }

    private void OnDisable()
    {
        _enemyMover.Reached -= Deactivate;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Target>(out _))
            _enemyMover.SetIsCollided(true);
    }

    private void Init(Transform target, Color color)
    {
        _enemyMover.SetTarget(target);
        _enemyMover.SetIsCollided(false);

        ChangeColor(color);
    }

    public void StartLiveCycle(Transform target, Color color)
    {
        Init(target, color);

        _coroutine = StartCoroutine(_enemyMover.TravellingTime());
    }

    private void Deactivate()
    {
        StopCoroutine(_coroutine);

        Deactivated?.Invoke(this);
    }

    private void ChangeColor(Color color)
    {
        _painter.ChangeColor(color);
    }
}