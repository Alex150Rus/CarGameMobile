using Game.Transport;
using Tools;
using UnityEngine;

namespace Game.Car
{
    internal sealed class CarController: TransportController
    {
        private readonly CarView _view;

        public GameObject ViewGameObject => _view.gameObject;

        public CarController()
        {
            ResourcePath = new ResourcePath("Prefabs/Car");
            _view = LoadView<CarView>();
        }
    }
}