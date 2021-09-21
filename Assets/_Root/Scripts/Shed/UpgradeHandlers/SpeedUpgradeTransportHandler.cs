namespace Shed.UpgradeHandlers
{
    internal class SpeedUpgradeTransportHandler: IUpgradeTransportHandler
    {
        private readonly float _speed;

        public SpeedUpgradeTransportHandler(float speed) => _speed = speed;
        
        public IUpgradeableTransport Upgrade(IUpgradeableTransport upgradeableTransport)
        {
            upgradeableTransport.Speed = _speed;
            return upgradeableTransport;
        }
    }
}