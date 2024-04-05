
using System.ComponentModel.DataAnnotations;

namespace Games.DAL.Data.Models
{
    public class Device : BaseEntity
    {
        [MaxLength(50)]
        public string Icon { get; set; } = string.Empty;
        public ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}
