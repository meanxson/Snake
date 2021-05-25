using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class HumansGroup : MonoBehaviour
{
    [SerializeField] private Humans[] _humans;

    private ColorsController _colors;

    private void Awake() => _colors = FindObjectOfType<ColorsController>();

    private void Start() => InitHumansColor(_colors.Colors);

    public void InitHumansColor(List<Color32> currentColor, int index = 0)
    {
        var colors = new Queue<Color32>();
        var secondColor = ReversedColor(currentColor);
        
        colors.Enqueue(currentColor[index]);
        colors.Enqueue(secondColor[index]);

        var humanIndex = Random.Range(0, _humans.Length);

        foreach (var dummy in _humans)
        {
            _humans[humanIndex].SetHumansColors(colors.Dequeue());

            if (humanIndex == 0)
                humanIndex++;
            else
                humanIndex = 0;
        }
    }

    private List<Color32> ReversedColor(List<Color32> colors)
    {
        var tempColors = new List<Color32>();
        
        for (var i = colors.Count - 1; i >= 0; i--) tempColors.Add(colors[i]);

        return tempColors;
    }
    
}