using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class UF
    {
        [Required(ErrorMessage = "Obrigatório informar código.")]
        [RegularExpression("[0-9]{2}", ErrorMessage = "Obrigatório informar dois digitos numericos.")]
        public string Cd_uf { get; set; } = string.Empty;
        [Required(ErrorMessage = "Obrigatório informar nome estado.")]
        [MaxLength(50, ErrorMessage = "Nome estado deve possuir no maximo 50 caracteres.")]
        public string Ds_uf { get; set; } = string.Empty;
        [Required(ErrorMessage = "Obrigatório informar sigla estado.")]
        [Range(2, 2, ErrorMessage = "Sigla deve possuir dois caracteres.")]
        public string Sigla { get; set; } = string.Empty;
    }
}
