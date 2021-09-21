namespace Shed.UpgradeHandlers
{
    internal interface IUpgradeableTransport
    {
        float Speed { get; set; }
        float JumpHeight { get; set; }

        void Restore();
    }
}