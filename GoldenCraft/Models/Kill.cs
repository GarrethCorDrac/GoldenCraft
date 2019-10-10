using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenCraft.Models
{
    [Table("stats_kill")]
    public class Kill
    {
        [Column("player")]
        public byte[] PlayerUuid { get; set; }
        public byte[] World { get; set; }
        public string VictimType { get; set; }
        public string VictimName { get; set; }
        public string Weapon { get; set; }
        public double Amount { get; set; }
        [Timestamp]
        [Column("last_updated")]
        public byte[] LastUpdated { get; set; }

        [ForeignKey("PlayerUuid")]
        public Player Player { get; set; }

    }
}
