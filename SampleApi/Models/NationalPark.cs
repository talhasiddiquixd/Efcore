using System.ComponentModel.DataAnnotations;

namespace SampleApi.Models
{
    public class NationalPark
    {
        [Key]
        public int Id { get; set; } 
        [Required]  
        public string ?Name { get; set; }
        public string? State { get; set; }
        public  DateTime? CreatedAt { get; set; }
        public DateTime? Established { get; set; }
    }
}
