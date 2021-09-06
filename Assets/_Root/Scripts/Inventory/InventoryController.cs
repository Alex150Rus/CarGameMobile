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
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Inventory");
        
        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private IInventoryView _inventoryView;
        private Transform _placeForUi;

        public InventoryController(
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IItemsRepository itemsRepository,
            [NotNull] Transform placeForUi
        )
        {
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            _placeForUi = placeForUi ?? throw new ArgumentNullException();
        }
        
        public void ShowInventory(Action callback)
        {
            _inventoryView ??= LoadView();
            _inventoryView.Display(_inventoryModel.GetEquippedItems());
            
        }
        

        public void HideInventory()
        {
        }
        
        private IInventoryView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadResource<GameObject>(_viewPath);
            GameObject objectView = Object.Instantiate(prefab, _placeForUi);
            AddGameObject(objectView);
            return objectView.GetComponent<IInventoryView>();
        }
    }
}