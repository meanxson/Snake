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
    public HumansGroup HumansGroup => _humansGroup;
    
    public void Spawn(int trailStartPositionZ, int index = 0)
    {
        _spawnPoint.localPosition = new Vector3(0, 0, trailStartPositionZ);
        for (var i = 0; i < _humanCount; i++)
        {
            trailStartPositionZ += _spawnRange;
            Instantiate(_humansGroup.gameObject, _spawnPoint.position.normalized, Quaternion.identity, _spawnPoint);

            _spawnPoint.localPosition = new Vector3(0, 0, trailStartPositionZ);
        }
    }
}
