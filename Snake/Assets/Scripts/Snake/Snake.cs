using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Snake : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _tailSize;
    [SerializeField] private float _tailSpringiness;
    [SerializeField] private SnakeHead _head;

    private TailGenerator _tailGenerator;

    private Renderer _renderer;
    private SnakeInput _input;

    public Color Color { get; private set; }
    
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
        var headTransform = _head.transform;
        
        Move(headTransform.position + headTransform.forward * (_speed * Time.fixedDeltaTime));
        _head.transform.forward = _input.GetDirectionToClick(transform.position);
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

    public void Lose()
    {
        
    }
}