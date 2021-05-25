using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Human : MonoBehaviour
{
   private Renderer _renderer;

   public Color32 Color { get; private set; }

   private void Awake()
   {
      _renderer = GetComponent<Renderer>();
   }

   public void SetColor(Color32 color)
   {
      Color = color;
      _renderer.material.color = color;
   }

   public void Collect()
   {
      Debug.Log("Taken");
      Destroy(gameObject);
   }
}
