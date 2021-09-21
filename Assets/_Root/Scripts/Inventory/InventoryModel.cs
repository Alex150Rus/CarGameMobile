using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Inventory.Items;

namespace Inventory
{
    internal interface IInventoryModel
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void EquipItem(IItem item);
        void UnequipItem(IItem item);
    }
    
    internal class InventoryModel: IInventoryModel
    {
        private readonly List<IItem> _items = new List<IItem>();

        public IReadOnlyList<IItem> GetEquippedItems() => _items;

        public void EquipItem(IItem item)
        {
            if (_items.Contains(item))
                return;
            
            _items.Add(item);
        }

        public void UnequipItem(IItem item)
        {
            if (!_items.Contains(item))
                return;

            _items.Remove(item);
        }
    }
}