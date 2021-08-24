using Game.Car;
using Tools;
using UnityEngine;

namespace Profile
{
    internal sealed class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly CarModel CurrentCar;

        public ProfilePlayer(float speedCar, GameState initialState): this(speedCar) =>
            CurrentState.Value = initialState;

        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new CarModel(speedCar);
        }
    }
}