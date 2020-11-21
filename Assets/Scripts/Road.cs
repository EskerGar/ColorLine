using System.Collections.Generic;
using UnityEngine;


public class Road : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Bezier bezier;
    [SerializeField] private float step;

    private void Start()
    {
        GenerateRoad();
    }

    private void GenerateRoad()
    {
        for (float i = 0; i < 1; i += step)
        {
            var go = Instantiate(prefab);
            go.transform.position = bezier.GetMovePoint(i) - new Vector3(0, .5f);
            go.transform.rotation = Quaternion.LookRotation(bezier.GetVelocity(i));
        }

    }
}
