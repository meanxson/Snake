using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
   private Renderer _renderer;
   
   private void Awake() => _renderer = GetComponent<Renderer>();

   public void InitColor(Color color)
   {
      _renderer.material.color = color;
   }
}
