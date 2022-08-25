using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace contrato.servicios.Client.Request
{
    public class AddClientRequest
    {

        [Required]
        [MinLength(4, ErrorMessage ="El nombre necesita minimo 4 letras")]
        public string Name { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "El apellido necesita minimo 4 letras")]
        public string LastName { get; set; }

        [Required]
        public int Dni { get; set; }

        [Required]
        [RegularExpression( "^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "No es un numero de telefono valido")]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "El formato del correo es inválido")]
        public string Email { get; set; }

    }
}
