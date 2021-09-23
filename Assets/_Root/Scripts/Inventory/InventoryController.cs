using System;
using Game.TapeBackground;
using Inventory.Items;
using JetBrains.Annotations;
using Profile;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Inventory
{
    internal interface IInventoryController
    {
        void ShowInventory(Action callback);
        void HideInventory();
    }
    
    
    internal class InventoryController: BaseViewController, IInventoryController
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly ProfilePlayer _profilePlayer;
        private readonly IItemsRepository _itemsRepository;
        private IInventoryView _inventoryView;
        private ItemViewController _itemViewController;

        public InventoryController(
            [NotNull] ProfilePlayer profilePlayer,
            [NotNull] IItemsRepository itemsRepository,
            [NotNull] Transform placeForUi
        )
        {
            _profilePlayer = profilePlayer ?? throw new ArgumentNullException(nameof(_profilePlayer));
            _inventoryModel = profilePlayer.Inventory ?? throw new ArgumentNullException(nameof(_inventoryModel));
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            Parent = placeForUi ?? throw new ArgumentNullException();
            ResourcePath = new ResourcePath("Prefabs/Inventory/Inventory");

            _inventoryView = LoadView<IInventoryView>();
            _inventoryView.Init(HideInventory);
            _itemViewController = new ItemViewController(_inventoryView.GetTransform(),
                _inventoryModel.GetEquippedItems());
            AddController(_itemViewController);
        }
        
        public void ShowInventory(Action callback)
        {
            _inventoryView.Display();
        }
        

        public void HideInventory()
        {
            _inventoryView.Close();
            _profilePlayer.CurrentState.Value = _profilePlayer.CurrentState.PreviousValue;
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            _itemViewController?.Dispose();
        }
    }
}