using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFDataLayer.Models
{
    [PrimaryKey(nameof(Id), nameof(Name))]
    public class PlayerEF
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public PlayerEF()
        {

        }
        public PlayerEF(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
