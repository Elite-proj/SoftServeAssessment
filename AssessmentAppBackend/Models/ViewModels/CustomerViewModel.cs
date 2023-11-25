namespace AssessmentAppBackend.Models.ViewModels
{
    public class CustomerViewModel
    {
        //This view model was created to make date formating easier

        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string DateOfBirth { get; set; }
        public int age { get; set; }
        public string DateCreated { get; set; }
        public string DateEdited { get; set; }
        public bool isDeleted { get; set; }
    }
}
