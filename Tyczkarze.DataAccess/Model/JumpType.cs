using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class JumpType
    {
        [Key]
        public int IdJumpType { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Jump> Jumps { get; set; }
    }
}
