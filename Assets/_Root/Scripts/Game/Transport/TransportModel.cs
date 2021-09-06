using Datas;
using Shed.UpgradeHandlers;

namespace Game.Transport
{
    internal abstract class TransportModel: IUpgradeableTransport
    {
        public float Speed { get; set; }
        public float JumpHeight { get; set; }
        public VehicleType Type { get; }

        private readonly float _defaultSpeed;
        
        public TransportModel(float speed, float jumpHeight, VehicleType type)
        {
            Speed = speed;
            JumpHeight = jumpHeight;
            _defaultSpeed = speed;
            Type = type;
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
        }
    }
}