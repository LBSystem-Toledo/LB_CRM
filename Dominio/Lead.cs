using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Lead
    {
        public int Id_lead { get; set; }
        [Required(ErrorMessage = "Obrigatório informar Segmento.")]
        public int Id_segmento { get; set; }
        [Required(ErrorMessage = "Obrigatório informar cidade.")]
        public string Cd_cidade { get; set; } = string.Empty;
        [Required(ErrorMessage = "Obrigatório informar nome.")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no maximo 50 caracteres.")]
        [Display(Name = "Nome Lead")]
        public string Nome { get; set; } = string.Empty;
        [EmailAddress(ErrorMessage = "E-mail em formato invalido.")]
        [MaxLength(255, ErrorMessage = "E-mail deve ter no maximo 255 caracteres.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = string.Empty;
        [Display(Name = "Telefone")]
        public string Fone { get; set; } = string.Empty;
        [Display(Name = "Celular")]
        public string Celular { get; set; } = string.Empty;
        [Display(Name = "Empresa")]
        [MaxLength(50, ErrorMessage = "Empresa deve ter no maximo 50 caracteres.")]
        public string Empresa { get; set; } = string.Empty;
        [Display(Name = "Endereço")]
        [MaxLength(50, ErrorMessage = "Endereço deve ter no maximo 50 caracteres.")]
        public string Endereco { get; set; } = string.Empty;
        [Display(Name = "Numero")]
        [MaxLength(10, ErrorMessage = "Numero deve ter no maximo 10 caracteres.")]
        public string Numero { get; set; } = string.Empty;
        [Display(Name = "Bairro")]
        [MaxLength(50, ErrorMessage = "Bairro deve ter no maximo 50 caracteres.")]
        public string Bairro { get; set; } = string.Empty;
    }
}
