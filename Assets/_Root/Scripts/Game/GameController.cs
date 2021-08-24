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
            var carController = new CarController();
            AddController(carController);
            AddController(tapeBackgroundController);
        }
    }
}