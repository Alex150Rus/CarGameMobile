using Tools;
using UnityEngine;

namespace Game.Car
{
    internal sealed class CarController: BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Car");
        private readonly CarView _view;

        public GameObject ViewGameObject => _view.gameObject;

        public CarController()
        {
            _view = LoadView();
        }

        private CarView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadResource<GameObject>(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);
            return objectView.GetComponent<CarView>();
        }
    }
}