using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorsController : MonoBehaviour
{
    [SerializeField] private int _colorCount;
    
    public readonly List<Color> Colors;

    public Color CurrentColor { get; private set; }

    private void Awake()
    {
        InitColors();
    }

    private void InitColors()
    {
        for (var i = 0; i < _colorCount; i++)
            Colors.Add(new Color32((byte) Random.Range(0, 255), (byte) Random.Range(0, 255),
                (byte) Random.Range(0, 255), 255));
    }

    public Color SetColor(int index)
    {
        var tempColor = Colors[index];
        CurrentColor = tempColor;
        
        return CurrentColor;
    }
}