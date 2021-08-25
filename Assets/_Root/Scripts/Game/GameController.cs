using System;
using Datas;
using Game.Car;
using Game.TapeBackground;
using Profile;
using Tools;
using UnityEngine;

namespace Game
{
    internal class GameController: BaseController
    {
        public GameController(ProfilePlayer profilePlayer)
        {
            /*
             * the car is moving to the left and to the right and our sub systems (paralax scrolling, input 
             * and car moving) will be subscribed to change in position;
            */
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);
            
            // var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            // AddController(inputGameController);

            SetVehicleController(profilePlayer);
            
        }

        private void SetVehicleController(ProfilePlayer profilePlayer)
        {
            switch (profilePlayer.CurrentVehicleType)
            {
                case VehicleType.Car:
                    var carController = new CarController();
                    AddController(carController);
                    break;
                case VehicleType.Boat:
                    throw new NotImplementedException();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}