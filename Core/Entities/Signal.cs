namespace Core.Entities
{
    public class Signal : BaseEntity
    {
        public string Name { get; set; }
        public string IrData { get; set; }

        public string AssignedButton { get; set; }

        public DateTime CreatedAt { get; set; }

        public SignalProtocol SignalProtocol { get; set; }
        public int SignalProtocolId { get; set; }
    }
}