using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humans : MonoBehaviour
{
    private Human[] _humans;
    private ColorsController _colors;

    private void Awake()
    {
        _humans = GetComponentsInChildren<Human>();
        _colors = FindObjectOfType<ColorsController>();
    }

    private void Start()
    {
        foreach (var human in _humans)
        {
            human.SetColor(_colors.CurrentColor);
        }
    }
}
