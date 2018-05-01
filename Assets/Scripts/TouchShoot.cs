using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchShoot : MonoBehaviour {

    public LayerMask touchMask = -1;
    public GameObject explosion;

    public void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, touchMask))
                {
                    if (explosion != null)
                    {
                        Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                    }
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
