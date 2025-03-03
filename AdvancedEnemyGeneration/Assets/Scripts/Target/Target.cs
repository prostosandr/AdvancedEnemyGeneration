using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Painter _painter;

    private void Awake()
    {
        _painter.ChangeToRandomColor();
    }
}