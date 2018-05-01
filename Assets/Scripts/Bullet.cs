using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;

    public void LateUpdate()
    {
        PlayerShip.Rotate(transform);

        transform.position += transform.forward * speed * Time.deltaTime;

        if (transform.position.sqrMagnitude > 1e5)
            Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
