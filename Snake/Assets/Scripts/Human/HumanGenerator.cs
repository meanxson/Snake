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

    public HumansGroup HumansGroup => _humansGroup;
    
    public void Spawn(HumansGroup humansGroup, int trailStartPositionZ)
    {
        _spawnPoint.localPosition = new Vector3(0, 0, trailStartPositionZ);
        for (var i = 0; i < _humanCount; i++)
        {
            trailStartPositionZ += _spawnRange;
            Instantiate(humansGroup, _spawnPoint.position.normalized, Quaternion.identity, _spawnPoint);
            _spawnPoint.localPosition = new Vector3(0, 0, trailStartPositionZ);
        }
    }
}
