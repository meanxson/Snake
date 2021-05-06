using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humans : MonoBehaviour
{
    private Human[] _humans;

    private void Awake()
    {
        _humans = GetComponentsInChildren<Human>();
    }
}
