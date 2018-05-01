using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePawn : MonoBehaviour {

    public float minRange = 200f;
    public float maxRange = 300f;

    public float frequency = 0.3f;
    private float spawnTime = 0;

    public GameObject[] spawnList = new GameObject[0];

    public void Update()
    {
        if (spawnList.Length <= 0)
            return;

        spawnTime += Time.deltaTime;

        if (spawnTime < frequency)
            return;

        Vector3 direction = Random.onUnitSphere;

        float distance = Random.Range(minRange, maxRange);
        Vector3 position = direction * distance;

        int index = Random.Range(0, spawnList.Length);
        if (spawnList[index] == null)
            return;

        Instantiate(spawnList[index], position, Random.rotation);

        spawnTime -= frequency;
    }
}
