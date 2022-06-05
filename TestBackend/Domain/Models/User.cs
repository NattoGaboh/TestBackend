using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestBackend.Domain.Models
{
	public class User
	{
		public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string NameUser { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; } = string.Empty;
    }
}

