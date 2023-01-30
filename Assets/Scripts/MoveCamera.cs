using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float panSpeed = 10f;

    void Update()
    {
        if (Input.GetMouseButton(0)) // right mouse button
        {
            var newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;
            // translates to the opposite direction of mouse position.
            transform.Translate(-newPosition);
        }
    }
}
