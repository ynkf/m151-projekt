namespace ClassRoom.Models.TransferModels
{
    public class StudentMarkTransferModel
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public int? Mark { get; set; }
    }
}
