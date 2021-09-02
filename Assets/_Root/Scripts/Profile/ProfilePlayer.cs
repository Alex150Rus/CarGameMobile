using System.Linq;
using Datas;
using Game.Car;
using Tools;

namespace Profile
{
    internal sealed class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly CarModel CurrentCar;
        public readonly VehicleType CurrentVehicleType;

        public ProfilePlayer(PlayerData playerData, GameState initialState): this(playerData) =>
            CurrentState.Value = initialState;

        public ProfilePlayer(PlayerData playerData)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new CarModel(
                playerData.Vehicles.Where(veh => veh.Type == playerData.CurrentVehicle).ToArray()[0].Speed);
            CurrentVehicleType = VehicleType.Car;
        }
    }
}