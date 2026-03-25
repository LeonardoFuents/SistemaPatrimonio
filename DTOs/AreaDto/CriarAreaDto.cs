using System.ComponentModel.DataAnnotations;

namespace SistemaPatrimonio.DTOs.AreaDto
{
    public class CriarAreaDto
    {
        [Required(ErrorMessage = "O nome da área é obrigatório.")]
        [StringLength(50,ErrorMessage = "O nome da área deve conter no máximo 50 caracteres.")]
        public string NomeArea { get; set; } = string.Empty; 
        // string.Empty = nulo é proibido
        //string? = pode ser null
        //null! = "relaxa,confia"
    }
}
