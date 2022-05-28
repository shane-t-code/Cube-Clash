using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private float destroyTime = 1.5f;
    //private Vector3 Offset = new Vector3(-1f, 0, 0);
    //private Vector3 RandomizeIntensity = new Vector3(0.5f, 0, 0);

    private void Update()
    {
        Destroy(gameObject, destroyTime);

        //transform.localPosition += Offset;
        //transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.y),
        //Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y),
        //Random.Range(-RandomizeIntensity.z, RandomizeIntensity.z));
    }

    private void LateUpdate()
    {
        var cameraToLookAt = Camera.main;
        transform.LookAt(cameraToLookAt.transform);
        transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);
    }
}
