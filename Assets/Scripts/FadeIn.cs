using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    public float maxVolume = 1f;
    public float fadeLenght = 1f;
    private float fadeStartTime = -1f;

    public void Awake()
    {

        if (GetComponent<AudioSource>() == null)
        {
            Destroy(gameObject);
            return;
        }

        GetComponent<AudioSource>().volume = 0;

        if (!GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Play();

    }

    public void Update()
    {
        if (fadeStartTime < 0)
        {
            fadeStartTime = Time.time;
        }

        if (fadeStartTime + fadeLenght < Time.time)
        {
            GetComponent<AudioSource>().volume = maxVolume;
            Destroy(this);
            return;
        }
        float progress = (Time.time - fadeStartTime) / fadeLenght;
        GetComponent<AudioSource>().volume = maxVolume * progress;
    }
}
