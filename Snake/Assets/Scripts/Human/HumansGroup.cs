using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class HumansGroup : MonoBehaviour
{
    [SerializeField] private Humans[] _humans;
    
    public void InitHumansColor(List<Color32> currentColor)
    {
        var colors = new Queue<Color32>();


        colors.Enqueue(currentColor[0]);
        colors.Enqueue(new Color32((byte) Random.Range(0, 255), (byte) Random.Range(0, 255),
            (byte) Random.Range(0, 255), 255));

        var index = Random.Range(0, _humans.Length);
        var color = colors.Dequeue();

        foreach (var dummy in _humans)
        {
            _humans[index].SetHumansColors(color);

            if (index == 0)
                index++;
            else
                index = 0;
        }
    }
}