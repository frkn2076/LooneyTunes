using System.ComponentModel.DataAnnotations;

namespace LooneyTunes.Models
{
    public class Cartoon
    {
        [Key]
        public int CartoonId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

    }
}
