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

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        Snake = GetComponentInParent<Snake>();
    }

    public void Move(Vector3 newPosition) => _rigidbody.MovePosition(newPosition);

    public IEnumerator SwitchColor(Color color, float duration)
    {
        _renderer.material.DOColor(color, duration);

        foreach (var snakeTail in Snake.Tails)
        {
            snakeTail.Renderer.material.DOColor(color, duration);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
