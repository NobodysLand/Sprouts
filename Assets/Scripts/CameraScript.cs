using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Camera cam;
    public float panSpeed = 10f;

    private void Start()
    {
        Screen.SetResolution(1280, 720, true, 60);
    }

    void Update()
    {
        //if (Input.GetMouseButton(1)) // right mouse button
        //{
        //    var newPosition = new Vector3();
        //    newPosition.x = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
        //    newPosition.y = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;
        //    // translates to the opposite direction of mouse position.
        //    transform.Translate(-newPosition);
        //    if (transform.position.x > 0.76f)
        //    {
        //        transform.position = new Vector3(0.76f, transform.position.y, transform.position.z);
        //    }
        //    if (transform.position.x < -0.86f)
        //    {
        //        transform.position = new Vector3(-0.86f, transform.position.y, transform.position.z);
        //    }
        //    if (transform.position.y > 0.60f)
        //    {
        //        transform.position = new Vector3(transform.position.x, 0.60f, transform.position.z);
        //    }
        //    if (transform.position.y < -0.60f)
        //    {
        //        transform.position = new Vector3(transform.position.x, -0.60f, transform.position.z);
        //    }
        //    Debug.Log(transform.position);

        //}

        //if (cam.orthographic)
        //{
        //    cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * panSpeed;
        //}
        //else
        //{
        //    cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * panSpeed;
        //}

    }
}
