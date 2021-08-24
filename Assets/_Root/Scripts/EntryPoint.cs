using System;
using Profile;
using UnityEngine;

internal sealed class EntryPoint: MonoBehaviour
{
    [SerializeField] private Transform _placeForUI;

    private MainController _mainController;

    private void Awake()
    {
        var speedCar = 15f;
        var profilePlayer = new ProfilePlayer(speedCar, GameState.Start);
        _mainController = new MainController(_placeForUI, profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
    }
}