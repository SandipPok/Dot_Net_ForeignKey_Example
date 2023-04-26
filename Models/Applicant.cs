using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MultipleConnection.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Gender { get; set; }

        [Required]
        [Range(20,50, ErrorMessage = "No any vacant position for your age")]
        public int Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Qualification { get; set; }

        [Required]
        [Range(1,25, ErrorMessage = "Currrntly, we have no vacant position for your experience")]
        [DisplayName("Total Experience in Years")]
        public int TotalExperience { get; set; }

        public virtual List<Experience> Experiences { get; set; } = new List<Experience>();
    }
}
