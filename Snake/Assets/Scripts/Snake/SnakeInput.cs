using UnityEngine;

public class SnakeInput : MonoBehaviour
{
   private Camera _camera;

   private void Start()
   {
      _camera = Camera.main;
   }


   public Vector3 GetDirection(Transform head)
   {
      Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
      var rotation = transform.eulerAngles;

      RaycastHit hit = new RaycastHit();

      if (Physics.Raycast(ray, out hit))
      {
         head.LookAt(hit.point);
         rotation = new Vector3(0, transform.eulerAngles.y, 0);
      }

      return rotation;
   }
}
