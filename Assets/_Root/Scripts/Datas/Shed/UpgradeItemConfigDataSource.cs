using System.Collections.Generic;
using UnityEngine;

namespace Datas.Shed
{
    [CreateAssetMenu(fileName = nameof(UpgradeItemConfigDataSource), menuName = "Data/Shed/" + 
        nameof(UpgradeItemConfigDataSource), order = 0)]
    internal class UpgradeItemConfigDataSource : ScriptableObject
    {
        [SerializeField] private UpgradeItemConfig[] _itemConfigs;

        public IReadOnlyList<UpgradeItemConfig> ItemConfigs => _itemConfigs;
    }
}