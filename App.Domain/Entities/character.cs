using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Character
    {
        public Character()
        {
            created = DateTime.UtcNow; 
        }

        public int Id { get; set; }
        [MaxLength(255)]
        public string name { get; set; }
        [MaxLength(255)]
        public string status { get; set; }
        [MaxLength(255)]
        public string species { get; set; }
        [MaxLength(255)]
        public string type { get; set; }
        [MaxLength(255)]
        public string gender { get; set; }
        // episode ve character alanlarının oluşturmamızı istediğiniz için ekstra Origin ve location için bir table oluşturmadım 
        [MaxLength(500)]
        public string origin { get; set; }
        [MaxLength(500)]
        public string location { get; set; }
        public DateTime created { get; set; }

        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();


    }
}
