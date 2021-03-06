﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if(player != null)
            transform.position = player.transform.position + _offset;
    }
}
