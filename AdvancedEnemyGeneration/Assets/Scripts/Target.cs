using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private Painter _painter;
    [SerializeField] private float _speed;
    [SerializeField] private bool _canMoveBackwards;

    private void Awake()
    {
        transform.position = _startPoint.position;
        _painter.ChangeToRandomColor();
    }

    private void Update()
    {
        if (_canMoveBackwards == false)
        {
            Displacement(_endPoint.position);

            if (transform.position == _endPoint.position)
                _canMoveBackwards = true;
        }
        else
        {
            Displacement(_startPoint.position);

            if (transform.position == _startPoint.position)
                _canMoveBackwards = false;
        }
    }

    private void Displacement(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}