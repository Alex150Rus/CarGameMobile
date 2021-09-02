using System;
using Datas;
using Game.Car;
using Game.InputLogic;
using Game.TapeBackground;
using Profile;
using Tools;
using UnityEngine;

namespace Game
{
    internal class GameController: BaseController
    {
        private TapeBackgroundController _tapeBackgroundController;
        public GameController(ProfilePlayer profilePlayer)
        {
            /*
             * the car is moving to the left and to the right and our sub systems (paralax scrolling, input 
             * and car moving) will be subscribed to change in position;
            */
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

            _tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController( _tapeBackgroundController);
            
            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);

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

        protected override void OnDisposed()
        {
            _tapeBackgroundController?.Dispose();
        }
    }
}