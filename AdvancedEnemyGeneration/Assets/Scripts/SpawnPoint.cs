using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Painter _painter;

    public Transform Target => _target;

    public void SetTarget(Transform target, Color color)
    {
        _target = target;
        ChangeColor(color);
    }

    private void ChangeColor(Color color)
    {
        _painter.ChangeColor(color);
    }
}