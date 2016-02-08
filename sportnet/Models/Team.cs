using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sportnet.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Coaches { get; set; }
    }
}