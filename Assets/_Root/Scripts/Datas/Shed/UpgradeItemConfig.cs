using Datas.Inventory;
using UnityEngine;

namespace Datas.Shed
{
    [CreateAssetMenu(fileName = nameof(UpgradeItemConfig), menuName = "Data/Shed/" + nameof(UpgradeItemConfig), order = 0)]
    internal class UpgradeItemConfig : ScriptableObject
    {
        [field: SerializeField] public ItemConfig ItemConfig { get; private set; }
        [field: SerializeField] public UpgradeType Type { get; private set; }
        [field: SerializeField] public float Value { get; private set; }

        public int id => ItemConfig.Id;
    }
}