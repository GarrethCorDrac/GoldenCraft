using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenCraft.Models
{
    [Table("stats_players")]
    public class Player
    {
        public int Id { get; set; }
        public byte[] Uuid { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Kill> Kills { get; set; }
        public virtual ICollection<Move> Moves { get; set; }
        public virtual ICollection<BlockBreak> BlockBreaks { get; set; }
    }
}
