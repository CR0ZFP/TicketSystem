using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Entitites.Entities
{
    public class Problem : IIdEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [MaxLength(450)]
        public string UserId { get; set; }

        public AppUser User { get; set; }
        public DateTime Date { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
    }
}
