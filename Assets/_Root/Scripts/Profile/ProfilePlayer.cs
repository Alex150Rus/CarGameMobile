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
        public readonly ShopTools Shop;
        public readonly InventoryModel Inventory;

        public ProfilePlayer(PlayerData playerData, GameState initialState, ShopTools shop) : this(playerData)
        {
            CurrentState.Value = initialState;
            Shop = shop;
        }

        public ProfilePlayer(PlayerData playerData)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentTransport = new CarModel(
                playerData.Vehicles.Where(veh => veh.Type == playerData.CurrentVehicle).ToArray()[0].Speed,
                playerData.CurrentVehicle
            );
            CurrentVehicleType = playerData.CurrentVehicle;
            Inventory = new InventoryModel();
        }
    }
}