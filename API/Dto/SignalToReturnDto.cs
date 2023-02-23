namespace API.Dto
{
    public class SignalToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IrData { get; set; }

        public string AssignedButton { get; set; }

        public string CreatedAt { get; set; }

        public string SignalProtocol { get; set; }
    }
}