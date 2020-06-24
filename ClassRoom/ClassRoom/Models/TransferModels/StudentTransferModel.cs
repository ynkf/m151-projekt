namespace ClassRoom.Models.TransferModels
{
    public class StudentTransferModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}
