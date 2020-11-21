using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class MoveComponent : MonoBehaviour
{
    [SerializeField] private Bezier bezier;
    [SerializeField] private float speed;

    private float _t;

    private void Start()
    {
        transform.position = bezier.GetMovePoint(_t);

    }

    private void Update()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Stationary) return;
        _t += speed * Time.deltaTime;
        transform.position = bezier.GetMovePoint(_t);
        transform.rotation = Quaternion.LookRotation(bezier.GetVelocity(_t));
    }
    
}
