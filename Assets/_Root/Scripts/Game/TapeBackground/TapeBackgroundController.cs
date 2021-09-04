using Tools;
using UnityEngine;

namespace Game.TapeBackground
{
    internal sealed class TapeBackgroundController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/background");
        private TapeBackgroundView _view;
        private readonly SubscriptionProperty<float> _diff;
        
        // come from Input
        private readonly ISubscriptionProperty<float> _leftMove;
        private readonly ISubscriptionProperty<float> _rightMove;

        public TapeBackgroundController(ISubscriptionProperty<float> leftMove, ISubscriptionProperty<float> rightMove)
        {
            _view = LoadView();
            _diff = new SubscriptionProperty<float>();

            _leftMove = leftMove;
            _rightMove = rightMove;

            _view.Init(_diff);
            
            _leftMove.SubscribeOnChange(Move);
            _rightMove.SubscribeOnChange(Move);
        }

        private void Move(float value) => _diff.Value = value;

        private TapeBackgroundView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadResource<GameObject>(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);
            return objectView.GetComponent<TapeBackgroundView>();
        }

        protected override void OnDisposed()
        {
            _leftMove.UnSubscribeOnChange(Move);
            _rightMove.UnSubscribeOnChange(Move);
        }
    }
}