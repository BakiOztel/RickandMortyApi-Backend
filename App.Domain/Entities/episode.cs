using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Episode
    {
        public Episode()
        {
            created = DateTime.UtcNow;
        }
        public int Id { get; set; }
        [MaxLength(500)]
        public string name { get; set; }
        [MaxLength(500)]
        public string episode { get; set; }
        public DateTime air_date { get; set; }
        public DateTime created { get; set; }
        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
