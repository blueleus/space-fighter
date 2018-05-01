using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

    public float speed = 10f;
    public TiltSteering tilt;

    private static PlayerShip use;

    public void Awake() {
        use = this;
    }

    public static Quaternion GetRotation() {
        if (use == null)
            return Quaternion.identity;
        return use.transform.rotation;
    }

    public static void Rotate(Transform other) {
        if (use == null) return;
        Vector3 euler = use.transform.eulerAngles;

        if (euler.x > 180f) euler.x -= 360f;
        if (euler.y > 180f) euler.y -= 360f;

        euler.Scale(new Vector3(use.tilt.vertRotateSpeed, use.tilt.horizRotateSpeed, 0));
        euler *= Time.deltaTime;

        Quaternion mirror = Quaternion.Euler(-euler);

        other.position = mirror * other.position;
        other.position -= use.transform.rotation * Vector3.forward * use.speed * Time.deltaTime;
        other.rotation *= mirror;
    } 
}
