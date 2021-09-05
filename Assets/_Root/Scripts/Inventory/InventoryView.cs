using System;
using System.Collections.Generic;
using Inventory.Items;
using UnityEngine;

namespace Inventory
{

    internal interface IInventoryView
    {
        event Action<IItem> Selected;
        event Action<IItem> Deselected;

        void Display(List<IItem> itemInfoCollection);
    }

    internal class InventoryView: MonoBehaviour, IInventoryView
    {
        public event Action<IItem> Selected;
        public event Action<IItem> Deselected;

        private List<IItem> _itemInfoCollection;
        
        
        public void Display(List<IItem> itemInfoCollection)
        {
           _itemInfoCollection = itemInfoCollection;
        }

        protected void OnSelected(IItem item) => Selected?.Invoke(item);
        protected void OnDeselected(IItem item) => Deselected?.Invoke(item);
    }
}