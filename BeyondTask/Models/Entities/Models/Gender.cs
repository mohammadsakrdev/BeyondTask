using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BeyondTask.Models.Entities.Models
{
    [Table("Gender")]
    public class Gender : IEntity
    {
        [Key]
        [Column("GenderId")]
        public int Id { get; set; }

        public string GenderName { get; set; }
    }
}
