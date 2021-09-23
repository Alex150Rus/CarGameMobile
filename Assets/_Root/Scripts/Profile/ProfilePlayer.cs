using System.Linq;
using Datas;
using Game.Car;
using Game.Transport;
using Inventory;
using Services.Shop;
using Tools;

namespace Profile
{
    internal sealed class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly TransportModel CurrentTransport;
        public readonly VehicleType CurrentVehicleType;
        public readonly InventoryModel Inventory;

        public ProfilePlayer(PlayerData playerData, GameState initialState) : this(playerData)
        {
            CurrentState.Value = initialState;
        }

        public ProfilePlayer(PlayerData playerData)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            var vehicle =  
                playerData.Vehicles.Where(veh => veh.Type == playerData.CurrentVehicle).ToArray()[0];
            CurrentTransport = new CarModel(vehicle.Speed, vehicle.JumpHeight, playerData.CurrentVehicle);
            CurrentVehicleType = playerData.CurrentVehicle;
            Inventory = new InventoryModel();
        }
    }
}