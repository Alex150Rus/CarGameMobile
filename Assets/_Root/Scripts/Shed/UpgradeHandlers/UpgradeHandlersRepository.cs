using System;
using System.Collections.Generic;
using Datas.Shed;

namespace Shed.UpgradeHandlers
{
    internal class UpgradeHandlersRepository: IRepository
    {
        private readonly Dictionary<int, IUpgradeTransportHandler> _upgradeHandlersMapById =
            new Dictionary<int, IUpgradeTransportHandler>();

        public IReadOnlyDictionary<int, IUpgradeTransportHandler> UpgradableItems => _upgradeHandlersMapById;

        public UpgradeHandlersRepository(IReadOnlyList<UpgradeItemConfig> upgradeItemConfigs) =>
            PopulateItems(ref _upgradeHandlersMapById, upgradeItemConfigs);

        private void PopulateItems(ref Dictionary<int, IUpgradeTransportHandler> upgradeHandlersMapByType, 
            IReadOnlyList<UpgradeItemConfig> upgradeItemConfigs)
        {
            foreach (var config in upgradeItemConfigs)
            {
                if(upgradeHandlersMapByType.ContainsKey(config.id) == false)
                    upgradeHandlersMapByType.Add(config.id, CreateHandlersByType(config));
            }
        }

        private IUpgradeTransportHandler CreateHandlersByType(UpgradeItemConfig config)
        {
            switch (config.Type)
            {
                case UpgradeType.Speed:
                    return new SpeedUpgradeTransportHandler(config.Value);
                default:
                    return StubUpgradeTransportHandler.Default;
            }
        }

        public void Dispose()
        {
            _upgradeHandlersMapById.Clear();
        }
        
        
    }
}