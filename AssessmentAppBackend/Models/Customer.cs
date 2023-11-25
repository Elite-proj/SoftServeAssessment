namespace AssessmentAppBackend.Models
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? UserName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int age { get; set; }
        public string? DateCreated { get; set; }
        public string? DateEdited { get; set; }
        public bool isDeleted { get; set; }
    }
}
