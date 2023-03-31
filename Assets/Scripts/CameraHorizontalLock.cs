using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHorizontalLock : MonoBehaviour
{
    public float cameraWidht = 10f;

    Camera _camera;

    bool isOrtho;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        isOrtho = _camera.orthographic;
    }

    // Update is called once per frame
    void Update()
    {
        FovUpdate();
    }

    public void FovUpdate()
    {
        

        if (isOrtho == false)
        {
            float halfWidth = Mathf.Tan(0.5f * cameraWidht * Mathf.Deg2Rad);

            float halfHeight = halfWidth * Screen.height / Screen.width;

            float verticalFoV = 2.0f * Mathf.Atan(halfHeight) * Mathf.Rad2Deg;

            _camera.fieldOfView = verticalFoV;
        }
        else
        {
            float unitsPerPixel = cameraWidht / Screen.width;

            float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

            _camera.orthographicSize = desiredHalfHeight;
        }
    }
}
