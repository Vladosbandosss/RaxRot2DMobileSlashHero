using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShakeCamera : MonoBehaviour
{
    public static ShakeCamera instance;
    
    private float origCameraposY;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        origCameraposY = Camera.main.transform.position.y;
    }

    IEnumerator Shakes()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector2 ranpos = Random.insideUnitCircle * 1.5f;
            Camera.main.transform.position = new Vector3(ranpos.x, ranpos.y,Camera.main.transform.position.z);
            yield return null;
        }

        Vector3 temp = Camera.main.transform.position;
        temp.y = origCameraposY;
        Camera.main.transform.position=temp;
    }

    public void Shake()
    {
      StartCoroutine(nameof(Shakes));
    }
}
