using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public Renderer Renderer { get; private set; }

    private void Awake() => Renderer = GetComponent<Renderer>();
}
