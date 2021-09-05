namespace Game.Transport
{
    internal abstract class TransportModel
    {
        public readonly float Speed;
        
        public TransportModel(float speed) => Speed = speed;
    }
}