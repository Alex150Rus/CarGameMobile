namespace Shed.UpgradeHandlers
{
    internal interface IUpgradeableTransport
    {
        float Speed { get; set; }

        void Restore();
    }
}