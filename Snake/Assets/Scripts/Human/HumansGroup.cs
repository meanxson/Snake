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

    private void Start() => InitHumansColor(_colors.SetColors);

    private void InitHumansColor(List<Color32> currentColor, int index = 0)
    {
        var colors = new Queue<Color32>();
        
        colors.Enqueue(currentColor[0]);
        colors.Enqueue(currentColor[1]);

        var humanRandomIndex = Random.Range(0, _humans.Length);

        foreach (var dummy in _humans)
        {
            _humans[humanRandomIndex].SetHumansColors(colors.Dequeue());

            if (humanRandomIndex == 0)
                humanRandomIndex++;
            else
                humanRandomIndex = 0;
        }
    }

    private List<Color32> ReversedColor(List<Color32> colors)
    {
        var tempColors = new List<Color32>();
        
        for (int i = colors.Count - 1; i >= 0; i--) tempColors.Add(colors[i]);

        return tempColors;
    }
    
}