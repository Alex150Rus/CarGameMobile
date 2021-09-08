using System;
using Game.TapeBackground;
using Inventory.Items;
using JetBrains.Annotations;
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
    
    
    internal class InventoryController: BaseController, IInventoryController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Inventory/Inventory");
        
        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private IInventoryView _inventoryView;
        private Transform _placeForUi;
        private ItemViewController _itemViewController;

        public InventoryController(
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IItemsRepository itemsRepository,
            [NotNull] Transform placeForUi
        )
        {
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            _placeForUi = placeForUi ?? throw new ArgumentNullException();

            _inventoryView = LoadView();
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
        }
        
        private IInventoryView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadResource<GameObject>(_viewPath);
            GameObject objectView = Object.Instantiate(prefab, _placeForUi);
            AddGameObject(objectView);
            return objectView.GetComponent<IInventoryView>();
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            _itemViewController?.Dispose();
        }
    }
}