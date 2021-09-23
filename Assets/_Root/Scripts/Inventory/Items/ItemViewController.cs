using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Inventory.Items
{
    internal class ItemViewController: BaseViewController
    {
        private GameObject _prefab;

        private IReadOnlyList<IItem> _items;

        public ItemViewController(Transform parent, IReadOnlyList<IItem> items)
        {
            ResourcePath = new ResourcePath("Prefabs/Inventory/ItemView");
            Parent = parent;
            _items = items;
            _prefab = ResourcesLoader.LoadResource<GameObject>(ResourcePath);
            LoadViews();
        }

        private void LoadViews()
        {
            foreach (var item in _items)
            {                
                var itemView = LoadView<ItemView>(_prefab);
                itemView.Init(item);
            }
        }
    }
}