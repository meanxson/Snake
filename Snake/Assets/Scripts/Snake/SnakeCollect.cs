using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeCollect : MonoBehaviour
{
    private SnakeHead _head;
    private Snake _snake;

    public int HumanEatenPoint { get; private set; } = 0;

    public event UnityAction Eaten;
    
    private void Awake()
    {
        _head = GetComponentInParent<SnakeHead>();
        _snake = GetComponentInParent<Snake>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Human human) && human.Color.Equals(_head.Color))
        {
            human.Collect();
            HumanEatenPoint++;
            Eaten?.Invoke();
        }
        else { } 
    }
}
