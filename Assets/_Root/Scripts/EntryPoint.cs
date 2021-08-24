using System;
using UnityEngine;

internal sealed class EntryPoint: MonoBehaviour
{
    [SerializeField] private Transform _placeForUI;

    private MainController _mainController;

    private void Awake()
    {
        _mainController = new MainController();
    }
}