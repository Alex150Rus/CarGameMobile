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

        public InventoryController(
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IItemsRepository itemsRepository
        )
        {
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
        }
        
        public void ShowInventory(Action callback)
        {
            _inventoryView ??= LoadView();
        }
        

        public void HideInventory()
        {
        }
        
        private IInventoryView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadResource<GameObject>(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);
            return objectView.GetComponent<IInventoryView>();
        }
    }
}