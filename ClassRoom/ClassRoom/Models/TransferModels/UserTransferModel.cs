namespace ClassRoom.Models.TransferModels
{
    public class UserTransferModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public UserTypes UserType { get; set; }
    }

    public enum UserTypes
    {
        User,
        Student,
        Teacher
    }
}
