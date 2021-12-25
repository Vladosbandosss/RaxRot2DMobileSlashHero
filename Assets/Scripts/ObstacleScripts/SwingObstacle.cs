using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingObstacle : MonoBehaviour
{
   [SerializeField] private float rotateSpeed=80f;

    private float zAngle;

    [SerializeField] private float minZRotation=-0.6f, maxZRotation=0.6f;
    
    private void Update()
    {
        zAngle += Time.deltaTime * rotateSpeed;
        transform.rotation=Quaternion.AngleAxis(zAngle,Vector3.forward);

        if (transform.rotation.z < minZRotation)
        {
            rotateSpeed = Mathf.Abs(rotateSpeed);
        }
        
        if (transform.rotation.z > maxZRotation)
        {
            rotateSpeed = -Mathf.Abs(rotateSpeed);
        }
    }
}
