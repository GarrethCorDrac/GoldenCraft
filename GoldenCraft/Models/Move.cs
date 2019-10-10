using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenCraft.Models
{
    [Table("stats_move")]
    public class Move
    {
        [Column("player")]
        public byte[] PlayerUuid { get; set; }
        public byte[] World { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        [Timestamp]
        [Column("last_updated")]
        public byte[] LastUpdated { get; set; }

        [ForeignKey("PlayerUuid")]
        public Player Player { get; set; }
    }
}
