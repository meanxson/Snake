using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointView : MonoBehaviour
{
    [SerializeField] private SnakeCollect _snakeCollect;
    [SerializeField] private TMP_Text _pointView;

    private void OnEnable() 
        => _snakeCollect.Eaten += OnEaten;

    private void OnDisable() 
        => _snakeCollect.Eaten -= OnEaten;

    private void OnEaten() 
        => _pointView.text = _snakeCollect.HumanEatenPoint.ToString();
}
