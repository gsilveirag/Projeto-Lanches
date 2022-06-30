using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage ="Informe o nome da categoria")]
        [MinLength(5, ErrorMessage ="O tamanho minimo e de {1}.")]
        [MaxLength(20, ErrorMessage ="O tamanho maximo é de {1}")]
        [Display(Name ="Nome da Categoria")]
        public string CategoriaName { get; set; }
        [Required(ErrorMessage = "Informe a descricao da categoria")]
        [MinLength(10, ErrorMessage = "O tamanho minimo e de {1}.")]
        [MaxLength(100, ErrorMessage = "O tamanho maximo é de {1}")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set; }   
    }
}
