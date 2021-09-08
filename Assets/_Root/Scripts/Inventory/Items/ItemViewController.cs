using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Inventory.Items
{
    internal class ItemViewController: BaseController
    {
        private ResourcePath _viewPath = new ResourcePath("Prefabs/Inventory/ItemView");
        private Transform _parent;
        private GameObject _prefab;

        private IReadOnlyList<IItem> _items;

        public ItemViewController(Transform parent, IReadOnlyList<IItem> items)
        {
            _parent = parent;
            _items = items;
            LoadViews();
        }

        private void LoadViews()
        {
            foreach (var item in _items)
            {
                _prefab ??= ResourcesLoader.LoadResource<GameObject>(_viewPath);
                GameObject objectView = Object.Instantiate(_prefab, _parent);
                var itemView = objectView.GetComponent<ItemView>();
                itemView.Init(item);
                AddGameObject(objectView);   
            }
        }
    }
}