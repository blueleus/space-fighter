using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour {

    public float warningDist = 100f;

    public void Update()
    {
        if (GetComponent<AudioSource>() == null)
        {
            return;
        }

        float distance = transform.position.sqrMagnitude;
        if (distance > warningDist * warningDist)
        {
            GetComponent<AudioSource>().volume = 0;
            return;
        }

        float volume = 1 - (distance / (warningDist * warningDist));
        GetComponent<AudioSource>().volume = volume;
    }
}
