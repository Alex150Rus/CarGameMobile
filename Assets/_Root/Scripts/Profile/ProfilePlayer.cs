using System.Linq;
using Datas;
using Game.Car;
using Services.Shop;
using Tools;

namespace Profile
{
    internal sealed class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly CarModel CurrentCar;
        public readonly VehicleType CurrentVehicleType;
        public readonly ShopTools Shop;

        public ProfilePlayer(PlayerData playerData, GameState initialState, ShopTools shop): this(playerData) {
            CurrentState.Value = initialState;
            Shop = shop;
        }

        public ProfilePlayer(PlayerData playerData)
        {
            
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new CarModel(
                playerData.Vehicles.Where(veh => veh.Type == playerData.CurrentVehicle).ToArray()[0].Speed);
            CurrentVehicleType = VehicleType.Car;
        }
    }
}