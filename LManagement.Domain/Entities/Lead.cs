using System.ComponentModel.DataAnnotations;

namespace LManagement.Domain.Entities
{
    public class Lead
    {
        public int Id { get; set;  }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Company { get; set; }
        public string Status { get; set; } = "New";
        public string? ZohoBiginId { get; set; }
        public string Source { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsSyncedToZoho { get; set; } = false;
    }
}
