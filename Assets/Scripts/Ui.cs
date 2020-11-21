using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{
    [SerializeField] private CubeDeath cubeDeath;

    private void Start()
    {
        cubeDeath.OnDead += ShowUi;
        gameObject.SetActive(false);
    }

    private void ShowUi() => gameObject.SetActive(true);

    private void OnDestroy()
    {
        cubeDeath.OnDead -= ShowUi;
    }
}
