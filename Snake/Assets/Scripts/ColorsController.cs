using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorsController : MonoBehaviour
{
    [SerializeField] private int _colorCount;
    public List<Color32> Colors { get; } = new List<Color32>();
    
    private void OnEnable() 
        => InitColors();

    private void InitColors()
    {
        for (var i = 0; i < _colorCount; i++)
        {
            Colors.Add(new Color32((byte) Random.Range(0,255),(byte) Random.Range(0,255),
                (byte) Random.Range(0,255), 255));
        }
    }
}