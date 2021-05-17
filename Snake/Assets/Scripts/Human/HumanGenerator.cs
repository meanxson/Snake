using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGenerator : MonoBehaviour
{
    [SerializeField] private int _humanCount;
    [SerializeField] private int _spawnRange;
    [SerializeField] private HumansGroup _humansGroup;
    [SerializeField] private Transform _spawnPoint;

    private ColorsController _colors;

    private void Awake() => _colors = GetComponent<ColorsController>();

    public int HumanCount => _humanCount;
    
    public HumansGroup HumansGroup => _humansGroup;
    
    public void Spawn(HumansGroup humansGroup, int trailStartPositionZ)
    {
        _spawnPoint.localPosition = new Vector3(0, 0, trailStartPositionZ);
        for (var i = 0; i < _humanCount; i++)
        {
            trailStartPositionZ += _spawnRange;
            Instantiate(humansGroup, _spawnPoint.position.normalized, Quaternion.identity, _spawnPoint);
            _humansGroup.InitHumansColor(_colors.Colors);
            
            _spawnPoint.localPosition = new Vector3(0, 0, trailStartPositionZ);
        }
    }
}
