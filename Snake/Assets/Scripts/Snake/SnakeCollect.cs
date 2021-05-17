using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeCollect : MonoBehaviour
{
    private SnakeHead _head;
    private Snake _snake;

    private void Awake()
    {
        _head = GetComponentInParent<SnakeHead>();
        _snake = GetComponentInParent<Snake>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Human human)) 
           human.Collect();
    }
}
