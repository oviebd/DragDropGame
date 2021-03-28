using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{

    void OnDrawGizmosSelected()
    {
        Camera camera = GetComponent<Camera>();
        Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(p,1.0F);
    }
}
