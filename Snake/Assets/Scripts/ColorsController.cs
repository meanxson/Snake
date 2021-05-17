using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorsController : MonoBehaviour
{
    [SerializeField] private int _colorCount;
    public List<Color32> Colors { get; } = new List<Color32>();

    [HideInInspector] public int Index;
    [HideInInspector] public List<Color32> SetColors;
    
    private void OnEnable() 
        => InitColors();

    private void InitColors()
    {
        Colors.Add(new Color32(37, 250, 255, 255));
        Colors.Add(new Color32(255, 195, 0, 255));
        Colors.Add(new Color32(255, 0, 183, 255));
        Colors.Add(new Color32(255, 3, 0, 255));
        Colors.Add(new Color32(107, 255, 125, 255));
        Colors.Add(new Color32(0, 3, 255, 255));
    }
}