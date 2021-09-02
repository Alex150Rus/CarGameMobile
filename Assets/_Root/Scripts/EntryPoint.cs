using System;
using Datas;
using Profile;
using UnityEngine;

internal sealed class EntryPoint: MonoBehaviour
{
    [SerializeField] private Transform _placeForUI;
    [SerializeField] private PlayerData _data;

    private MainController _mainController;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(_data, GameState.Start);
        _mainController = new MainController(_placeForUI, profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
    }
}