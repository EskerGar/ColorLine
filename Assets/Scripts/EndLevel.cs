using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private LoadLevel _loadLevel;

    private void Start()
    {
        _loadLevel = GetComponent<LoadLevel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var cube = other.GetComponent<MoveComponent>();
        if (cube != null)
            _loadLevel.DownloadLevel();
    }
}
