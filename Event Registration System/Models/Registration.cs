using System.ComponentModel.DataAnnotations;


namespace Event_Registration_System.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }

        [Required(ErrorMessage = "Participant name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string ParticipantName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Event ID is required.")]
        public int EventId { get; set; }

        // Navigation property (if using EF Core)
        public Event Event { get; set; }
    }
}
