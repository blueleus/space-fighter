using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour { 
    
    void Update()
    {
        if (GetComponent<ParticleSystem>() == null)
            Destroy(gameObject);
    }

    public void LateUpdate()
    {
        PlayerShip.Rotate(transform);
    }
}
