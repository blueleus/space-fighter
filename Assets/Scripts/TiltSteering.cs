using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltSteering : MonoBehaviour {

    public float horizRotateSpeed = 7f;
    public float vertRotateSpeed = 3f;

    public float horizMax = 60f;
    public float vertMax = 45f;

    public void Update()
    {
        Vector3 rotation = transform.eulerAngles;

        if (rotation.y > 180f)
            rotation.y -= 360f;
        if (rotation.x > 180f)
            rotation.x -= 360f;

        rotation.y += Input.acceleration.x * horizRotateSpeed;
        rotation.x += Input.acceleration.x * vertRotateSpeed;

        rotation.y = Mathf.Clamp(rotation.y, -horizMax, horizMax);
        rotation.x = Mathf.Clamp(rotation.x, -vertMax, vertMax);

        transform.eulerAngles = rotation;

    }
}
