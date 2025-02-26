using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Painter _painter;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isCollided;

    private Coroutine _coroutine;

    public event Action<Enemy> Deactivated;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Target>(out _))
            _isCollided = true;
    }

    private void Init(Transform target, Color color)
    {
        _target = target;
        _isCollided = false;

        ChangeColor(color);
    }

    public void StartLiveCycle(Transform target, Color color)
    {
        Init(target, color);

        _coroutine = StartCoroutine(TravellingTime());
    }

    private IEnumerator TravellingTime()
    {

        while (enabled)
        {
            if (_isCollided == false)
            {
                Displacement();

                yield return null;
            }
            else
            {
                break;
            }
        }

        Deactivate();
    }

    private void Displacement()
    {
        transform.LookAt(_target);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
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