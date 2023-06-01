namespace API.Dto
{
    public class SignalDto
    {
        public string Name { get; set; }
        public string IrData { get; set; }
        public string AssignedButton { get; set; }
        public string CreatedAt { get; set; }
        public int SignalProtocolId { get; set; }
    }
}