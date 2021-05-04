using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailGenerator : MonoBehaviour
{
    [SerializeField] private Segment _segmentTemplate;

    public List<Segment> Generate(int count)
    {
        var tails = new List<Segment>();

        for (var i = 0; i < count; i++) 
            tails.Add(Instantiate(_segmentTemplate, transform));

        return tails;
    }
}