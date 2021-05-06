using System;
using UnityEngine;

public class TrailGenerator : MonoBehaviour
{
    [SerializeField] private int _countOfTrail;
    [SerializeField] private Trail _trailSegment;
    [SerializeField] private ChangeColorPoint changeColorPoint;
    [SerializeField] private Transform _spawnPoint;
    
    private HumanGenerator _humanGenerator;

    private void Awake() => _humanGenerator = GetComponent<HumanGenerator>();

    private void Start()
    {
        var lenght = 0f;

        for (var i = 0; i < _countOfTrail; i++)
        {
            _spawnPoint.position = new Vector3(0, 0, lenght);
            Instantiate(_trailSegment, _spawnPoint.localPosition, Quaternion.identity, transform);
            _humanGenerator.Spawn(_humanGenerator.HumansGroup, 10);
            Instantiate(changeColorPoint, _spawnPoint.position, Quaternion.identity, transform);
            lenght += _trailSegment.Size * 10;
        }
    }
}