using System;
using UnityEngine;

namespace Datas
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 1)]
    internal class PlayerData: ScriptableObject
    {
        [Header("CurrentVehicle"), SerializeField] private VehicleType _currentVehicle;
        [SerializeField] private PlayerVehicles[] _vehicles;

        public VehicleType CurrentVehicle => _currentVehicle;
        public PlayerVehicles[] Vehicles => _vehicles;
    }
    
    [Serializable]
    internal struct PlayerVehicles
    {
        [SerializeField]
        private VehicleType _type;
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float JumpHeight { get; private set; }

        public VehicleType Type => _type;
        
    }
}