namespace Clases
{
    public class UserProfile
    {
        public string Id { get; set; } // FK a AspNetUsers.Id
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int? EstablishmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public virtual Establishment Establishment { get; set; }
    }
}
