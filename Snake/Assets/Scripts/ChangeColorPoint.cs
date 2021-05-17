using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeColorPoint : MonoBehaviour
{
    private ParticleSystem[] _particles;
    private BorderPoint _borderPoint;
    private ColorsController _colorsController;

    private int _colorIndex;

    private void Awake()
    {
        _particles = GetComponentsInChildren<ParticleSystem>();
        _borderPoint = GetComponentInChildren<BorderPoint>();
        _colorsController = FindObjectOfType<ColorsController>();
    }

    private void Start() => SetBorderColor(ref _colorIndex);

    private void SetBorderColor(ref int index)
    {
        index = Random.Range(0, _colorsController.Colors.Count);
        
        var color = _colorsController.Colors[index];

        foreach (var particle in _particles)
        {
            var particleMain = particle.main;
            particleMain.startColor = new ParticleSystem.MinMaxGradient(color);
        }
        _borderPoint.Renderer.material.color = color;
        _colorsController.SetColors.Add(color);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeHead snake))
            StartCoroutine(snake.SwitchColor(_colorsController.Colors[_colorIndex], 1f));
    }
}