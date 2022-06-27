using System;
using System.ComponentModel.DataAnnotations;

namespace contrato.entidades
{
    public class User
    {
        [Required]
        public  string NameUser { get; set; }
        [Required]
        public  string Password { get; set; }

    }
}