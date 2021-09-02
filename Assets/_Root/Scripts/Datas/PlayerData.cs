using System;
using UnityEngine;

namespace Datas
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 1)]
    internal class PlayerData: ScriptableObject
    {
        [Header("CurrentVehicle"), SerializeField] private VehicleType _currentVehicle;
        [SerializeField] private PlayerVehicles[] _vehicles;

        public VehicleType CurrentVehicle;
        public PlayerVehicles[] Vehicles => _vehicles;
    }
    
    [Serializable]
    internal struct PlayerVehicles
    {
        [SerializeField]
        private VehicleType _type;
        [SerializeField]
        private float _speed;

        public VehicleType Type => _type;
        public float Speed => _speed;
    }
}