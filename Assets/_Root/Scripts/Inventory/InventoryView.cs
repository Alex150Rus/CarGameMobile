using System;
using System.Collections.Generic;
using Inventory.Items;
using Tools;
using UnityEngine;
using Object = System.Object;

namespace Inventory
{

    internal interface IInventoryView
    {
        event Action<IItem> Selected;
        event Action<IItem> Deselected;

        void Display(IReadOnlyList<IItem> itemInfoCollection);

        public Transform GetTransform();
    }

    internal class InventoryView: MonoBehaviour, IInventoryView
    {
        [SerializeField] private Transform _grid;
        public event Action<IItem> Selected;
        public event Action<IItem> Deselected;

        private IReadOnlyList<IItem> _itemInfoCollection;
        
        
        public void Display(IReadOnlyList<IItem> itemInfoCollection)
        {
           _itemInfoCollection = itemInfoCollection;

        }

        public Transform GetTransform() => _grid;

        protected void OnSelected(IItem item) => Selected?.Invoke(item);
        protected void OnDeselected(IItem item) => Deselected?.Invoke(item);
    }
}