using System;
using UnityEngine;

public class Test01 : MonoBehaviour
{
    private void Update()
    {
        CastRay();
        Rotate();
    }

    private void CastRay()
    {
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.forward;

        // RaycastHit is a struct (value type)
        // Physics.Raycast() method below assigns to this variable
        RaycastHit hitInfo;

        // The raycast interacts with colliders
        // the out keyword is pass by reference but allows null references
        // this is in contrast to the ref keyword, which doesn't allow null
        bool rayCollision = Physics.Raycast(ray, out hitInfo);
        //bool rayCollision = Physics.Raycast(ray, out hitInfo, 100f);

        if (rayCollision)
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.direction * 100f, Color.green);
        }

        // you can also use LayerMask objects and pass them into the Physics.Raycast() method
        // public LayerMask layerMask; // set as a field
        // Physics.Raycast(ray, out hitInfo, layerMask);
        // this allows you to specify raycast detection for objects in specific layers
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.right);
    }

}
