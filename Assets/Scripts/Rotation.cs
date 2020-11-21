using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private void Update()
    {
        transform.Rotate(0f, rotationSpeed, 0f);
    }
}
