using System;
using UnityEngine;
using DG.Tweening;

public class ChangeColorPoint : MonoBehaviour
{
    private ParticleSystem[] _particles;
    private BorderPoint _borderPoint;

    private void Awake()
    {
        _particles = GetComponentsInChildren<ParticleSystem>();
        _borderPoint = GetComponentInChildren<BorderPoint>();
    }

    private void Start()
    {
        foreach (var particle in _particles)
        {
            var particleMain = particle.main;
            particleMain.startColor = new ParticleSystem.MinMaxGradient(new Color(1f, 0.2f, 0.4f));
        }

        _borderPoint.Renderer.material.color = new Color(1f, 0.2f, 0.4f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out SnakeHead snake))
            StartCoroutine(snake.SwitchColor(new Color(1f, 0.2f, 0.4f), 1f));
    }
}