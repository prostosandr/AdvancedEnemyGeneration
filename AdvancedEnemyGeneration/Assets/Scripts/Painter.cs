using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Painter : MonoBehaviour
{
    private Renderer _renderer;

    public Color Color => _renderer.material.color;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void ChangeColor(Color color)
    {
        _renderer.material.color = color;
    }

    public void ChangeToRandomColor()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
