namespace _Root.Scripts.Shed.UpgradeHandlers
{
    public interface IUpgradeableTransport
    {
        float Speed { get; set; }

        void Restore();
    }
}