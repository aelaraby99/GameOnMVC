using System.ComponentModel.DataAnnotations;

namespace Games.DAL.Data.Models
{
    public class Game : BaseEntity
    {
        [MaxLength(2500)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string CoverName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Device>? Devices { get; set; } = new HashSet<Device>();
    }
}
