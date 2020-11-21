using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var cube = other.GetComponent<CubeDeath>();
        if(cube != null)
            cube.Dying();
    }
}
