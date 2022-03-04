using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Cidade
    {
        [Required(ErrorMessage = "Obrigatório informar código.")]
        [RegularExpression("[0-9]{7}", ErrorMessage = "Obrigatório informar sete digitos numericos.")]
        public string Cd_cidade { get; set; } = string.Empty;
        [Required(ErrorMessage = "Obrigatório informar código UF")]
        public string Cd_uf { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        [Required(ErrorMessage = "Obrigatório informar nome cidade.")]
        [MaxLength(50, ErrorMessage = "Nome cidade deve ter no maximo 50 caracteres.")]
        public string Ds_cidade { get; set; } = string.Empty;
    }
}
