using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Vector2 camera_offset = new Vector2(3, 1);

    public Camera headCamera;
    public Camera camera;

    public float rot_speed = 3f;
    private float timeToChangeCamera;

    public GameObject player;
    private Camera currentCamera;
    private Vector3 MousePos;


    void Update()
    {
        if (currentCamera != null)
        {
            Vector3 delta = new Vector3(-Input.GetAxis("Mouse Y") * rot_speed, Input.GetAxis("Mouse X") * rot_speed, 0f);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + delta);
            transform.position = player.transform.position - (transform.forward * camera_offset.x) + (transform.up * camera_offset.y);
        }
    }

    public void СhangeCamera()
    {
        if (timeToChangeCamera == 0 || timeToChangeCamera < Time.time)
        {
            if (headCamera.gameObject.activeSelf)
                EnableCamera();
            else
                EnableHeadCamera();

            timeToChangeCamera = Time.time + 2;
        }
    }

    public void EnableHeadCamera()
    {
        headCamera.gameObject.SetActive(true);
        camera.gameObject.SetActive(false);
        currentCamera = headCamera;
    }

    public void EnableCamera()
    {
        headCamera.gameObject.SetActive(false);
        camera.gameObject.SetActive(true);
        currentCamera = camera;
    }
}
