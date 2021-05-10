using System;
using UnityEngine;

public class SnakeInput : MonoBehaviour
{
   private Camera _camera;

   private void Awake() => _camera = Camera.main;

   public Vector3 GetDirectionToClick(Vector3 headPosition)
   {
      var mousePosition = Input.mousePosition;
      var direction = Vector3.forward;

      mousePosition = _camera.ScreenToViewportPoint(mousePosition);
      
      if (Input.GetMouseButton(0))
         direction.x = mousePosition.x - headPosition.x;
      
      return direction;
   }
}
