using Game.Car;
using Tools;
using UnityEngine;

namespace Game.Transport.HatOnWheels
{
    internal class HatOnWheelsController: TransportController
    {
        private readonly HatOnWheelsView _view;

        public GameObject ViewGameObject => _view.gameObject;

        public HatOnWheelsController()
        {
            ResourcePath = new ResourcePath("Prefabs/HatOnWheels");
            _view = LoadView<HatOnWheelsView>();
        }
    }
}