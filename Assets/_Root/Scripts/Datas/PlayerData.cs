using System;
using System.Collections.Generic;
using UnityEngine;

namespace Datas
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 1)]
    internal class PlayerData: ScriptableObject
    {
        [SerializeField] private List<PlayerVehicles> _vehicles;
        public List<PlayerVehicles> Vehicles => _vehicles;
    }
    
    [Serializable]
    internal struct PlayerVehicles
    {
        public VehicleType Type;
        public float Speed;
    }
}