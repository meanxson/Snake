using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Humans : MonoBehaviour
{
    private Human[] _humans;

    private void Awake()
        => _humans = GetComponentsInChildren<Human>();

    public void SetHumansColors(Color32 color)
    {
        foreach (var human in _humans) 
            human.SetColor(color);
    }
}