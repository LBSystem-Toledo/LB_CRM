using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Segmento
    {
        [Required(ErrorMessage = "Obrigatório informar código.")]
        public int Id_segmento { get; set; }
        [Required(ErrorMessage = "Obrigatório informar descrição segmento.")]
        [MaxLength(50, ErrorMessage = "Descrição deve possuir no maximo 50 caracteres.")]
        public string Ds_segmento { get; set; } = string.Empty;
    }
}
