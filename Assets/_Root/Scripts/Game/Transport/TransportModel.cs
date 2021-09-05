using Datas;
using Shed.UpgradeHandlers;

namespace Game.Transport
{
    internal abstract class TransportModel: IUpgradeableTransport
    {
        public float Speed { get; set; }
        public VehicleType Type { get; }

        private readonly float _defaultSpeed;
        
        public TransportModel(float speed, VehicleType type)
        {
            Speed = speed;
            _defaultSpeed = speed;
            Type = type;
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
        }
    }
}