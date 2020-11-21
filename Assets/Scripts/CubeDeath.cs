using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDeath : MonoBehaviour
{
    public event Action OnDead;

    public void Dying()
    {
        OnDead?.Invoke();
        Destroy(gameObject);
    }
}
