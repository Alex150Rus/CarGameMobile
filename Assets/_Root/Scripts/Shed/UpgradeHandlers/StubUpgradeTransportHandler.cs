namespace Shed.UpgradeHandlers
{
    internal class StubUpgradeTransportHandler : IUpgradeTransportHandler
    {
        public static readonly IUpgradeTransportHandler Default = new StubUpgradeTransportHandler();
        
        public IUpgradeableTransport Upgrade(IUpgradeableTransport upgradeableTransport)
        {
            throw new System.NotImplementedException();
        }
    }
}