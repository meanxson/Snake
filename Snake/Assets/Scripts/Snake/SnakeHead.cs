using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class SnakeHead : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private Snake Snake;

    public Color Color { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        Snake = GetComponentInParent<Snake>();
    }

    private void Start()
    {
        _renderer.material.color = Snake.StartColor;
        foreach (var snakeTail in Snake.Tails) 
            snakeTail.Renderer.material.color = Snake.StartColor;
    }

    public void Move(Vector3 newPosition) => _rigidbody.MovePosition(newPosition);

    public IEnumerator SwitchColor(Color color, float duration)
    {
        _renderer.material.DOColor(color, duration);
        Color = color;
        
        foreach (var snakeTail in Snake.Tails)
        {
            snakeTail.Renderer.material.DOColor(color, duration);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
