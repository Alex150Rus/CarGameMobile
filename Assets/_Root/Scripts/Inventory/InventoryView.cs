using System;
using System.Collections.Generic;
using Inventory.Items;
using Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Object = System.Object;

namespace Inventory
{

    internal interface IInventoryView
    {
        event Action<IItem> Selected;
        event Action<IItem> Deselected;

        void Display();
        void Close();

        public Transform GetTransform();

        public void Init(UnityAction closeInventory);
    }

    internal class InventoryView: MonoBehaviour, IInventoryView
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Transform _grid;
        [SerializeField] private Button _buttonClose;
        public event Action<IItem> Selected;
        public event Action<IItem> Deselected;

        private IReadOnlyList<IItem> _itemInfoCollection;

        private UnityAction _closeInventory;
        
        
        public void Display()
        {
            ToggleCanvasGroupVisibility(true);
        }

        public void Close()
        {
            ToggleCanvasGroupVisibility(false);
        }

        private void ToggleCanvasGroupVisibility(bool isVisible)
        {
            _canvasGroup.alpha = isVisible ? 1 : 0;
            _canvasGroup.interactable = isVisible;
            _canvasGroup.blocksRaycasts = isVisible;
        }

        public void Init(UnityAction closeInventory)
        {
            _closeInventory = closeInventory;
            _buttonClose.onClick.AddListener(_closeInventory);
        }

        public Transform GetTransform() => _grid;

        protected void OnSelected(IItem item) => Selected?.Invoke(item);
        protected void OnDeselected(IItem item) => Deselected?.Invoke(item);

        private void OnDestroy()
        {
            _buttonClose.onClick.RemoveListener(_closeInventory);
        }
    }
}