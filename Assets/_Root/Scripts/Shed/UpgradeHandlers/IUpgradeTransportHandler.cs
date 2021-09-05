namespace Shed.UpgradeHandlers
{
    internal interface IUpgradeTransportHandler
    {
        IUpgradeableTransport Upgrade(IUpgradeableTransport upgradeableTransport);
    }
}