using System.Collections.Generic;
using Datas.Inventory;
using UnityEngine;

namespace Datas
{
    [CreateAssetMenu(fileName = nameof(InventoryModelConfig), menuName = "Data/Inventory/" + nameof(InventoryModelConfig))]
    internal class InventoryModelConfig : ScriptableObject
    {
        [SerializeField] private ItemConfig[] _items;

        public IReadOnlyList<ItemConfig> Items => _items;
    }
}