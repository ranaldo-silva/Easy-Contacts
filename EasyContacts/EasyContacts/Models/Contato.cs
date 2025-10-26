using System.ComponentModel.DataAnnotations; 

namespace EasyContacts.Models
{
    public class Contato
    {
        // Propriedade para identificar unicamente o contato
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; }

            // Requisito de usar tipo Data 
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

          // Requisito de usar Enum 
        [Display(Name = "Tipo de Contato")]
        public TipoContato Tipo { get; set; }
    }
}