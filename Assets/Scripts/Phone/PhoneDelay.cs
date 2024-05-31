using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneDelay : MonoBehaviour
{
    public Transform targetTransform;
    public float positionSmoothSpeed;
    public float rotationSmoothSpeed;

    void Update()
    {
        FollowWithDelay();
    }

    private void FollowWithDelay()
    {
        Vector3  newPos  = Vector3.Lerp(targetTransform.position, transform.position, positionSmoothSpeed);
        Quaternion NewRot = Quaternion.Slerp(transform.rotation, targetTransform.rotation, rotationSmoothSpeed);

        transform.position = newPos;
        transform.rotation = NewRot;
    }
}
