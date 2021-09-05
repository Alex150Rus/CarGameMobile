using Game.Car;
using Tools;
using UnityEngine;

namespace Game.Transport.HatOnWheels
{
    internal class HatOnWheelsController: TransportController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/HatOnWheels");
        private readonly HatOnWheelsView _view;

        public GameObject ViewGameObject => _view.gameObject;

        public HatOnWheelsController()
        {
            _view = LoadView();
        }

        private HatOnWheelsView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadResource<GameObject>(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);
            return objectView.GetComponent<HatOnWheelsView>();
        }
    }
}