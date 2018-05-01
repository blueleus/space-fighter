using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public float minSpeed = 5f;
    public float maxSpeed = 10f;

    private float speed = 1f;

    private Vector3 direction = Vector3.forward;

    public void Awake()
    {
        direction = Random.onUnitSphere;
        speed = Random.Range(minSpeed, maxSpeed);
    }

    public void LateUpdate()
    {
        Quaternion playerRotation = PlayerShip.GetRotation();
        PlayerShip.Rotate(transform);

        direction = playerRotation * direction;
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.sqrMagnitude > 1e5)
            Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
