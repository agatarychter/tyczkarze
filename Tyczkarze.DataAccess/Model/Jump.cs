using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class Jump
    {
        [Key]
        public int IdJump { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Height { get; set; }

        public int? StepsCount { get; set; }

        public string Note { get; set; }

        public int? IdJumpType { get; set; }

        public int? IdPole1 { get; set; }
        public int? IdPole2 { get; set; }
        public int? IdPole3 { get; set; }

        public int? IdJumpStatus1 { get; set; }
        public int? IdJumpStatus2 { get; set; }
        public int? IdJumpStatus3 { get; set; }

        public int? IdContest { get; set; }
        public int? IdElimination { get; set; }

        [ForeignKey("IdPole1")]
        public Pole Pole1 { get; set; }

        [ForeignKey("IdPole2")]
        public Pole Pole2 { get; set; }

        [ForeignKey("IdPole3")]
        public Pole Pole3 { get; set; }

        [ForeignKey("IdJumpStatus1")]
        public JumpStatus JumpStatus1 { get; set; }

        [ForeignKey("IdJumpStatus2")]
        public JumpStatus JumpStatus2 { get; set; }

        [ForeignKey("IdJumpStatus3")]
        public JumpStatus JumpStatus3 { get; set; }
    }
}
