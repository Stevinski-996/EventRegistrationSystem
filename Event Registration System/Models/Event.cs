using System;
using System.ComponentModel.DataAnnotations;


namespace Event_Registration_System.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        [Display(Name = "Event Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, 10000, ErrorMessage = "Capacity must be between 1 and 10,000.")]
        public int Capacity { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
