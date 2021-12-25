using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RotateObstacle : MonoBehaviour
{
    private float rotateSpeed;
    private float minRotateSpeed = 200f, maxRotateSpeed = 400f;
    private int changeSpeedDirection = -1;
    
    private float zAngle;

    private void Start()
    {
        rotateSpeed = Random.Range(minRotateSpeed,maxRotateSpeed);

        if (Random.Range(0, 2) > 0)
        {
            rotateSpeed *= changeSpeedDirection;
        }
    }

    private void Update()
    {
        zAngle += Time.deltaTime * rotateSpeed;
        transform.rotation=Quaternion.AngleAxis(zAngle,Vector3.forward);
    }
}
