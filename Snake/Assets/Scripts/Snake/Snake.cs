using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _tailSize;
    [SerializeField] private float _tailSpringiness;
    [SerializeField] private SnakeHead _head;

    private TailGenerator _tailGenerator;

    private Renderer _renderer;
    private SnakeInput _input;

    public List<Segment> Tails { get; private set; }

    private void Awake()
    {
        _tailGenerator = GetComponent<TailGenerator>();
        Tails = _tailGenerator.Generate(_tailSize);
        _renderer = GetComponent<Renderer>();
        _input = GetComponent<SnakeInput>();
    }

    private void FixedUpdate()
    {
        Move(_head.transform.position + _head.transform.forward * (_speed * Time.fixedDeltaTime));
        _head.transform.forward = _input.GetDirection(_head.transform);
    }

    private void Move(Vector3 nextPosition)
    {
        var previousPosition = _head.transform.position;

        foreach (var segment in Tails)
        {
            var tempPosition = segment.transform.position;

            segment.transform.position = Vector3.Lerp(segment.transform.position,
                previousPosition, _tailSpringiness * Time.fixedDeltaTime);

            previousPosition = tempPosition;
        }

        _head.Move(nextPosition);
    }
}