using System;
using Datas;
using Game.Car;
using Game.InputLogic;
using Game.TapeBackground;
using Game.Transport;
using Game.Transport.HatOnWheels;
using Profile;
using Services.Analytics;
using Tools;

namespace Game
{
    internal class GameController: BaseController
    {
        private TapeBackgroundController _tapeBackgroundController;
        private InputGameController _inputGameController;
        private TransportController _transportController;
        public GameController(ProfilePlayer profilePlayer)
        {
            AnalyticsManager.Instance.SendGameStarted();
            /*
             * the car is moving to the left and to the right and our sub systems (paralax scrolling, input 
             * and car moving) will be subscribed to change in position;
            */
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

            _tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController( _tapeBackgroundController);
            
            _inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentTransport);
            AddController(_inputGameController);

            SetVehicleController(profilePlayer);
        }

        private void SetVehicleController(ProfilePlayer profilePlayer)
        {
            switch (profilePlayer.CurrentVehicleType)
            {
                case VehicleType.Car:
                    _transportController = new CarController();
                    AddController(_transportController);
                    break;
                case VehicleType.HatOnWheels:
                    _transportController = new HatOnWheelsController();
                    AddController(_transportController);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override void OnDisposed()
        {
            _tapeBackgroundController?.Dispose();
            _inputGameController?.Dispose();
            _transportController?.Dispose();
        }
    }
}